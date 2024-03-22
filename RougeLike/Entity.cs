using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    internal class Entity : GameObject
    {
        public event Action<int> OnDamageTaken;

        private int hp;

        public int Hp
        {
            get => hp;
            protected set
            {
                hp = value;
                if (hp <= 0)
                {
                    Destroy();
                }
            }
        }

        public Entity(GameObjectManager gameObjectManager, Vector2 position, 
            bool isSolid, int hp, char icon) : base(position, gameObjectManager, isSolid, icon)
        {
            this.hp = hp;
        }

        public virtual void TakeDamage(int damage)
        {
            Hp -= damage;
            OnDamageTaken?.Invoke(damage);
        }

        public virtual void Move(Direction direction)
        {
            Vector2 newPosition;

            switch (direction)
            {
                case Direction.Up:
                    newPosition = Position + Vector2.Up;
                    break;
                case Direction.Down:
                    newPosition = Position + Vector2.Down;
                    break;
                case Direction.Left:
                    newPosition = Position + Vector2.Left;
                    break;
                case Direction.Right:
                    newPosition = Position + Vector2.Right;
                    break;
                default:
                    return;
            }

            if (gameObjectManager.IsPositionFree(newPosition))
            {
                Position = newPosition;
            }
        }
    }
}
