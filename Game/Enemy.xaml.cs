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
    /// Interakční logika pro Enemy.xaml
    /// </summary>
    public partial class Enemy : UserControl
    {
        private double HPmax = 20;
        private double HP { get; set; } = 20;

        int moveDownIteration = 0;

        public Enemy(int HPgiven)
        {
            InitializeComponent();

            HPmax = HP = HPgiven;

            UpdateLabel();
        }

        private void UpdateLabel()
        {
            HealthLabel.Content = HP + "/" + HPmax;
        }

        public void Injure(double dmg)
        {
            HP -= dmg;
            UpdateLabel();

            if (HP <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            var parent = this.Parent as Canvas;
            parent.Children.Remove(this);
        }

        public void MoveDown(object sender, EventArgs e)
        {
            Canvas.SetTop(this, Canvas.GetTop(this) + 5);
            moveDownIteration++;

            if (moveDownIteration >= 50)
            {
                moveDownIteration = 0;
                Wave.WTimer.Tick -= MoveDown;
            }
        }
    }
}
