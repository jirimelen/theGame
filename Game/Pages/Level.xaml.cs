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

namespace Game.Pages
{
    /// <summary>
    /// Interakční logika pro Level.xaml
    /// </summary>
    public partial class Level : Page
    {
        Frame frame;

        bool isShipOverloaded = false;
        double MaxOverload = 200;
        double Overload = 200;

        bool fireRateCooldown = false;

        public static DispatcherTimer LTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(10),
            IsEnabled = true
        };
        public static DispatcherTimer AutoShootTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(100),
            IsEnabled = true
        };

        WaveManager WManager;

        public Level()
        {
            InitializeComponent();
        }
        public Level(Frame mainFrame, int levelNum) : this()
        {
            frame = mainFrame;
            WManager = new WaveManager(GameCanvas, levelNum);
            Overload = 0;
            LTimer.Tick += CoolDown;
            AutoShootTimer.Tick += FireRateCool;
        }

        public void CoolDown(object sender, EventArgs e)
        {
            if (Overload > 0)
            {
                Overload -= 0.4;

                if (Overload <= 0)
                {
                    Overload = 0;
                    if (isShipOverloaded)
                    {
                        isShipOverloaded = false;
                        HeatBar.Background = new SolidColorBrush(Colors.Blue);
                    }
                }
                
                UpdateHeatBar();
            }
        }

        public void UpdateHeatBar()
        {
            if (Overload > 0)
            {
                double percentage = Overload / MaxOverload;
                HeatBar.Width = 447 * percentage;
            }
            else
            {
                HeatBar.Width = 0;
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = Mouse.GetPosition(GameCanvas);
            Canvas.SetLeft(Ship, position.X - 95);
            Canvas.SetTop(Ship, position.Y - 54);
        }

        private void GameCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isShipOverloaded)
            {
                //Shoot();
                AutoShootTimer.Tick += AutoShoot;
            }
            else
            {
                try
                {
                    AutoShootTimer.Tick -= AutoShoot;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EndLevel(bool didWin)
        {
            GameCanvas.MouseMove -= Canvas_MouseMove;
            GameCanvas.MouseDown -= GameCanvas_MouseDown;
            GameCanvas.Cursor = Cursors.Arrow;

            if (didWin)
            {
                modal_win.Visibility = Visibility.Visible;
            }
            else
            {
                Ship.Visibility = Visibility.Hidden;
                modal_lose.Visibility = Visibility.Visible;
            }
        }

        public void AutoShoot(object sender, EventArgs e)
        {
            Shoot();
        }

        public void Shoot()
        {
            if (!fireRateCooldown && !isShipOverloaded)
            {
                Point position = Mouse.GetPosition(GameCanvas);

                //Type PLType = typeof();
                Bullet projectileLeft = new Bullet { Damage = Ship.SideGunLeft.Damage }; //Activator.CreateInstance(typeof(Bullet)) as Bullet;
                Bullet projectileRight = new Bullet { Damage = Ship.sideGunRight.Damage }; //Activator.CreateInstance(typeof(Bullet)) as Bullet;

                projectileLeft.Width = 6;
                projectileLeft.Height = 6;
                projectileRight.Width = 6;
                projectileRight.Height = 6;

                GameCanvas.Children.Add(projectileLeft);
                Canvas.SetLeft(projectileLeft, position.X - 54);
                Canvas.SetTop(projectileLeft, position.Y - 52);
                GameCanvas.Children.Add(projectileRight);
                Canvas.SetLeft(projectileRight, position.X + 48);
                Canvas.SetTop(projectileRight, position.Y - 52);

                Bullet.BTimer.Tick += projectileLeft.MoveUp;
                Bullet.BTimer.Tick += projectileRight.MoveUp;

                fireRateCooldown = true;

                Overload += 7;
                if (Overload >= MaxOverload)
                {
                    Overload = MaxOverload;
                    isShipOverloaded = true;
                    HeatBar.Background = new SolidColorBrush(Colors.Orange);
                }

            }
        }

        public void FireRateCool(object sender, EventArgs e)
        {
            if (fireRateCooldown) fireRateCooldown = false;
        }

        public void UpdateHPBar(int Max, double Current)
        {
            double BarWidth = ( 447 / (double)Max ) * Current;
            if (BarWidth <= 0) {
                BarWidth = 0;
                EndLevel(false);
            } 
            HealthBar.Width = BarWidth;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ship.Injure(5);
        }

        private void Navigate_garage(object sender, RoutedEventArgs e)
        {
            GameCanvas.Children.Remove(Ship);
            frame.Navigate(new Garage(frame));
        }

        private void GameCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AutoShootTimer.Tick -= AutoShoot;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
