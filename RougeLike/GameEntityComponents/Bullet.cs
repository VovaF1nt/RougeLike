using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;

namespace RogueLike.GameEntityComponents
{
    internal class Bullet : GameObject
    {
        private Vector2 velocity;

        public Bullet(Vector2 position, GameObjectManager gameObjectManager, bool isSolid, char icon, Vector2 velocity) :
            base(position, gameObjectManager, isSolid, icon)
        {
            this.velocity = velocity;
        }

        public override void Update(double deltaTime)
        {
            Vector2 nextPosition = Position + velocity;

            if (gameObjectManager.IsPositionFree(nextPosition))
            {
                Position = nextPosition;
            }
            else
            {
                Destroy();
            }
        }

        public override void OnDestroyCallback(GameObject obj)
        {
            gameObjectManager.DestroyGameObject(obj);
        }
    }
}
