﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLike.UIComponents
{
    internal class HealthBar
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public HealthBar(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void SetHealth(int health)
        {
            CurrentHealth -= health;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }
    }
}
