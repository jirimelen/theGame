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
    /// Interakční logika pro SpaceShip.xaml
    /// </summary>
    public partial class SpaceShip : UserControl
    {
        public SideGun SideGunLeft = new MachineGun();
        public SideGun sideGunRight = new MachineGun();
        
        private int HPmax = 500;
        public double HP { get; set; } = 500;

        public SpaceShip()
        {
            InitializeComponent();
        }

        public void Injure(double dmg)
        {
            HP -= dmg;

            var Parent = this.Parent as Canvas;
            var MainGrid = Parent.Parent as Grid;
            var LevelPage = MainGrid.Parent as Pages.Level;

            LevelPage.UpdateHPBar(HPmax, HP);
        }
    }
}
