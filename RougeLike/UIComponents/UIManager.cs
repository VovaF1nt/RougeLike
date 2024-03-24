using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLike.GameCore;

namespace RogueLike.UIComponents
{
    internal class UIManager
    {
        public HealthBar HealthBar { get; set; }
        private GameObjectManager gameObjectManager;
        private HealthBarHandler healthBarHandler;
        public UIManager(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;
            HealthBar = new HealthBar(gameObjectManager.Player.Hp);
            healthBarHandler = new HealthBarHandler(HealthBar, gameObjectManager.Player);
        }
    }
}
