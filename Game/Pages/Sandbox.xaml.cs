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
    /// Interakční logika pro Sandbox.xaml
    /// </summary>
    public partial class Sandbox : Page
    {
        Frame frame;

        public static DispatcherTimer BossTimer = new DispatcherTimer()
        {
            Interval = TimeSpan.FromMilliseconds(10),
            IsEnabled = true
        };

        public Sandbox()
        {
            InitializeComponent();
        }
        public Sandbox(Frame mainFrame) : this()
        {
            frame = mainFrame;
        }
        /*
        Point LastIntersection = new Point();
        Point LastWeaponPoint = new Point();
        public void Adjust(double Xweapon, double Yweapon)
        {

            R2.X2 = Xweapon;// > 650 ? 650 : Xweapon;
            R2.Y2 = Yweapon;
            Point S1 = new Point { X = R1.X1, Y = R1.Y1 };
            Point S2 = new Point { X = R2.X2, Y = R2.Y2 };
            float Radius1 = 300;
            float Radius2 = 500;

            Point InterPoint1;
            Point InterPoint2;

            int IntersectionsFound = CircleIntersection(S1.X, S1.Y, Radius1, S2.X, S2.Y, Radius2, out InterPoint1, out InterPoint2);

            if (IntersectionsFound != 0)
            {
                R1.X2 = R2.X1 = InterPoint1.X;
                R1.Y2 = R2.Y1 = InterPoint1.Y;
                LastIntersection = InterPoint1;
                LastWeaponPoint = new Point { X = Xweapon, Y = Yweapon };
            }
            else
            {
                R2.X2 = LastWeaponPoint.X;
                R2.Y2 = LastWeaponPoint.Y;
                R1.X2 = R2.X1 = LastIntersection.X;
                R1.Y2 = R2.Y1 = LastIntersection.Y;
            }

        }

        private int CircleIntersection(
            double cx0, double cy0, double radius0,
            double cx1, double cy1, double radius1,
            out Point intersection1, out Point intersection2)
        {
            // Find the distance between the centers.
            double dx = cx0 - cx1;
            double dy = cy0 - cy1;
            double dist = Math.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new Point(double.NaN, double.NaN);
                intersection2 = new Point(double.NaN, double.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new Point(double.NaN, double.NaN);
                intersection2 = new Point(double.NaN, double.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new Point(double.NaN, double.NaN);
                intersection2 = new Point(double.NaN, double.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                double a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                double h = Math.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                double cx2 = cx0 + a * (cx1 - cx0) / dist;
                double cy2 = cy0 + a * (cy1 - cy0) / dist;

                // Get the points P3.
                intersection1 = new Point(
                    (double)(cx2 + h * (cy1 - cy0) / dist),
                    (double)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new Point(
                    (double)(cx2 - h * (cy1 - cy0) / dist),
                    (double)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }*/

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //Adjust(Mouse.GetPosition(SBcanvas).X, Mouse.GetPosition(SBcanvas).Y);
        }
    }
}
