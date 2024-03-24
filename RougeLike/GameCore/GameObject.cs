using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = RogueLike.Vector2;

namespace RogueLike.GameCore
{
    internal class GameObject
    {
        public Vector2 Position { get; protected set; }
        public char Icon { get; protected set; }
        public bool IsSolid { get; protected set; }
        public GameObjectManager gameObjectManager { get; private set; }

        public event Action<GameObject> onGameObjectDestroyed;
        public event Action onCollisionEntered;

        public GameObject(Vector2 position, GameObjectManager gameObjectManager, bool isSolid, char icon = '@')
        {
            Position = position;
            Icon = icon;
            IsSolid = isSolid;
            this.gameObjectManager = gameObjectManager;
            onGameObjectDestroyed += OnDestroyCallback;
            onCollisionEntered += OnCollisionEnterCallback;
        }

        public virtual void Update(double deltaTime)
        {
            CheckCollision();
        }
        public virtual void OnDestroyCallback(GameObject obj)
        {

        }

        public virtual void OnCollisionEnterCallback()
        {

        }

        public void Destroy()
        {
            onGameObjectDestroyed?.Invoke(this);
        }

        private void CheckCollision()
        {
            for (int i = gameObjectManager.GameObjects.Count - 1; i >= 0; i--)
            {
                GameObject gameObject = gameObjectManager.GameObjects[i];
                if (gameObject != this && gameObject.Position.Equals(Position))
                {
                    onCollisionEntered?.Invoke();
                }
            }
        }
    }
}
