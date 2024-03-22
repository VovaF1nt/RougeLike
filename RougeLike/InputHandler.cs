using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    internal class InputHandler
    {
        public Entity Player { get; private set; }

        public InputManager Input { get; private set; }

        public InputHandler(Entity player, InputManager input)
        {
            Input = input;
            Player = player;

            Input.OnMove += Player.Move;
        }
    }
}
