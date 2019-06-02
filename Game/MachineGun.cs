using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class MachineGun : SideGun
    {
        
        public MachineGun()
        {
            MaxLevel = 15;
            BaseDamage = 1;
            Multiplier = 2.5;
            // levelup to level 1
            this.LevelUp();

            Projectile = new Bullet { Damage = this.Damage };
        }

    }
}
