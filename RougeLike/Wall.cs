using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    internal class Wall : GameObject
    {
        public Wall(Vector2 position, GameObjectManager gameObjectManager, bool isSolid, char icon = '#') : 
            base(position, gameObjectManager, isSolid, icon)
        {

        }
    }
}
