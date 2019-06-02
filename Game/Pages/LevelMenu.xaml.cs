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

namespace Game.Pages
{
    /// <summary>
    /// Interakční logika pro LevelMenu.xaml
    /// </summary>
    public partial class LevelMenu : Page
    {
        Frame frame;
        PlanetInfoChart chart = new PlanetInfoChart();

        public LevelMenu()
        {
            InitializeComponent();
        }
        public LevelMenu(Frame mainFrame) : this()
        {
            frame = mainFrame;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            // blank
        }

        private void DisplayPlanetInfoChart(object sender, MouseEventArgs e)
        {
            var planet = sender as Planet;

            canvas.Children.Add(chart);
            Canvas.SetLeft(chart, Canvas.GetLeft(planet) + planet.Width + 10);
            Canvas.SetTop(chart, Canvas.GetTop(planet));
        }

        private void RemovePlanetInfoChart(object sender, MouseEventArgs e)
        {
            canvas.Children.Remove(chart);
        }

        private void Planet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frame.Navigate(new Level(frame, int.Parse((sender as Planet).Name.Replace("level", ""))));
        }
    }
}
