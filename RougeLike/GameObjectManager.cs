using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    internal class GameObjectManager
    {
        public event Action OnPlayerDestroyed;
        public event Action OnPlayerReachedExit;
        public List<GameObject> GameObjects { get; private set; }

        public Entity Player { get; private set; }

        public Entity[] SimpleEnemies { get; private set; }

        public Entity[] ShootingEnemies { get; private set; }

        public GameObject[] Walls { get; private set; }

        public Map Map { get; private set; }

        public GameObjectManager(int enemyNumber, int shootingEnemyNumber, int wallNumber)
        {
            GameObjects = new List<GameObject>();

            Map = new Map(this, wallNumber);

            SimpleEnemies = new Entity[enemyNumber];
            ShootingEnemies = new Entity[shootingEnemyNumber];


            CreateEntities();
        }

        public void Update(double deltaTime)
        {
            for (int i = GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = GameObjects[i];
                gameObject.Update(deltaTime);
            }

            if (!GameObjects.Contains(Player))
            {
                OnPlayerDestroyed?.Invoke();
            }

            if (Player.Position.Equals(Map.exitPosition))
            {
                OnPlayerReachedExit?.Invoke();
            }
        }

        public bool IsPositionFree(Vector2 position)
        {
            for (int i = GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = GameObjects[i];
                if (gameObject.Position.Equals(position) && gameObject.IsSolid)
                {
                    return false;
                }
            }

            return true;
        }

        private void CreateEntities()
        {

            Player = new Player(this, new Vector2(1, 1), false);
            RegisterGameObject(Player);

            for (int i = 0; i < SimpleEnemies.Length; i++)
            {
                SimpleEnemies[i] = new Enemy(this, Map.GenerateRandomPosition(), false);
                RegisterGameObject(SimpleEnemies[i]);
            }

            for (int i = 0; i < ShootingEnemies.Length; i++)
            {
                ShootingEnemies[i] = new ShootingEnemy(this, Map.GenerateRandomPosition(), false);
                RegisterGameObject(ShootingEnemies[i]);
            }
        }

        public void RegisterGameObject(GameObject gameObject)
        {
            GameObjects.Add(gameObject);
        }

        public void DestroyGameObject(GameObject gameObject)
        {
            GameObjects.Remove(gameObject);
        }

        public GameObject GetGameObjectAtPosition(Vector2 position)
        {
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.Position.Equals(position))
                    return gameObject;
            }

            return null;
        }
    }
}
