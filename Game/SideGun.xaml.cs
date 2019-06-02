using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game
{
    /// <summary>
    /// Interakční logika pro ASideGun.xaml
    /// </summary>
    public partial class SideGun : UserControl
    {
        protected int MaxLevel = 0;
        protected double BaseDamage = 0;
        protected double Multiplier = 0;

        public Bullet Projectile { get; set; }
        public double Damage { get; set; } = 0;
        public int Level { get; set; } = 0;
        
        public SideGun()
        {
            InitializeComponent();
        }

        public void LevelUp()
        {
            Level++;
            Damage = BaseDamage * Multiplier * Level;
        }
    }
}
