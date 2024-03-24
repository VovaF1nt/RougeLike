using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;

namespace RogueLike.GameEntityComponents
{
    internal class Player : Entity
    {
        Random random = new Random();

        public Player(GameObjectManager gameObjectManager, Vector2 position, bool isSolid, int hp = 100, char icon = 'K') :
            base(gameObjectManager, position, isSolid, hp, icon)
        {
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
        }

        public override void OnDestroyCallback(GameObject obj)
        {
            gameObjectManager.DestroyGameObject(obj);
        }

        public override void OnCollisionEnterCallback()
        {
            int damage = random.Next(1, 10);
            TakeDamage(damage);
        }
    }
}
