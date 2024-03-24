using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;

namespace RogueLike.HelpUtilities
{
    internal class Wall : GameObject
    {
        public Wall(Vector2 position, GameObjectManager gameObjectManager, bool isSolid, char icon = 'W') :
            base(position, gameObjectManager, isSolid, icon)
        {

        }
    }
}
