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
using System.Windows.Threading;

namespace Game
{
    /// <summary>
    /// Interakční logika pro Bullet.xaml
    /// </summary>
    public partial class Bullet : UserControl
    {
        public static DispatcherTimer BTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(10),
            IsEnabled = true
        };


        public double Damage { get; set; }

        public Bullet()
        {
            InitializeComponent();
        }

        public void MoveUp(object sender, EventArgs e)
        {
            Canvas.SetTop(this, Canvas.GetTop(this) - 3);

            CheckCollision();

            if (Canvas.GetTop(this) < 5)
            {
                this.Destroy();
            }
        }

        public void CheckCollision()
        {
            double Xpos = Canvas.GetLeft(this);
            double XposEnd = Xpos + this.Width;
            double Ypos = Canvas.GetTop(this);
            double YposEnd = Ypos + this.Height;

            var parentCanvas = this.Parent as Canvas;

            List<Enemy> Enemies = parentCanvas.Children.OfType<Enemy>().ToList();

            foreach (var enemy in Enemies)
            {
                double Xenemy = Canvas.GetLeft(enemy);
                double XenemyEnd = Xenemy + enemy.Width;

                if ((XposEnd > Xenemy && XposEnd < XenemyEnd) || (Xpos < XenemyEnd && Xpos > Xenemy))
                {
                    double Yenemy = Canvas.GetTop(enemy);
                    double YenemyEnd = Yenemy + enemy.Height;

                    if ((YposEnd > Yenemy && YposEnd < YenemyEnd) || (Ypos < YenemyEnd && Ypos > Yenemy))
                    {
                        enemy.Injure(this.Damage);
                        this.Destroy();
                    }
                }
            }
        }

        public void Destroy()
        {
            BTimer.Tick -= this.MoveUp;
            var parentCanvas = this.Parent as Canvas;
            if (parentCanvas != null) parentCanvas.Children.Remove(this);
        }
    }
}
