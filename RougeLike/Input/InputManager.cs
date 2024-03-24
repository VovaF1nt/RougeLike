using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike.HelpUtilities;

namespace RogueLike.Input
{
    internal class InputManager
    {
        public event Action<Direction> OnMove;
        public InputManager()
        {

        }
        public void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        OnMove?.Invoke(Direction.Up);
                        break;
                    case ConsoleKey.S:
                        OnMove?.Invoke(Direction.Down);
                        break;
                    case ConsoleKey.A:
                        OnMove?.Invoke(Direction.Left);
                        break;
                    case ConsoleKey.D:
                        OnMove?.Invoke(Direction.Right);
                        break;
                }
            }
        }
    }
}

