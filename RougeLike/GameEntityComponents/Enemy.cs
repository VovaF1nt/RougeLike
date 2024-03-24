using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;
using RogueLike.HelpUtilities;

namespace RogueLike.GameEntityComponents
{
    internal class Enemy : Entity
    {
        private double elapsedTimeSinceLastMove;
        private double moveInterval = 30;
        public Enemy(GameObjectManager gameObjectManager, Vector2 position, bool isSolid, int hp = 20, char icon = 'Õ') : base(gameObjectManager, position, isSolid, hp, icon)
        {
        }

        public override void Update(double deltaTime)
        {
            elapsedTimeSinceLastMove += deltaTime;

            if (elapsedTimeSinceLastMove >= moveInterval)
            {
                Move(GenerateRandomDirection());
                elapsedTimeSinceLastMove = 0;
            }
        }

        public override void Move(Direction direction)
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

        protected Direction GenerateRandomDirection()
        {
            Random random = new Random();
            int direction = random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    return Direction.Up;
                case 1:
                    return Direction.Down;
                case 2:
                    return Direction.Left;
                case 3:
                    return Direction.Right;
                default:
                    return Direction.Up;
            }
        }
    }
}
