using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike
{
    internal class HealthBarHandler
    {
        private HealthBar healthBar;
        private Entity player;
        public HealthBarHandler(HealthBar healthBar, Entity player)
        {
            this.healthBar = healthBar;
            this.player = player;

            player.OnDamageTaken += healthBar.SetHealth;
        }
    }
}
