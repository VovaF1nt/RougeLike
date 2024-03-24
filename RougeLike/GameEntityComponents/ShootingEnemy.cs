using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;

namespace RogueLike.GameEntityComponents
{
    internal class ShootingEnemy : Enemy
    {
        private DateTime lastShootTime;
        private int shootInterval = 1000;

        private static readonly Random random = new Random();

        public ShootingEnemy(GameObjectManager gameObjectManager, Vector2 position, bool isSolid, int hp = 20, char icon = 'A') :
            base(gameObjectManager, position, isSolid, hp, icon)
        {

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Shoot();
        }

        private void Shoot()
        {
            if ((DateTime.Now - lastShootTime).TotalMilliseconds >= shootInterval)
            {
                Bullet bullet = new Bullet(Position, gameObjectManager, false, '*', GetBulletVelocity());
                gameObjectManager.RegisterGameObject(bullet);
                lastShootTime = DateTime.Now;
            }
        }

        private Vector2 GetBulletVelocity()
        {
            int direction = random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    return Vector2.Up;
                case 1:
                    return Vector2.Down;
                case 2:
                    return Vector2.Left;
                case 3:
                    return Vector2.Right;
                default:
                    return Vector2.Up;
            }
        }
    }
}
