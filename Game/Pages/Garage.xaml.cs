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
    /// Interakční logika pro Garage.xaml
    /// </summary>
    public partial class Garage : Page
    {
        Frame frame;

        public static SpaceShip Ship = new SpaceShip();

        public Garage()
        {
            InitializeComponent();
            GarageCanvas.Children.Add(Ship);
            Canvas.SetLeft(Ship, 546);
            Canvas.SetTop(Ship, 349);
        }
        public Garage(Frame mainFrame) : this()
        {
            frame = mainFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GarageCanvas.Children.Remove(Ship);
            frame.Navigate(new LevelMenu(frame));
        }
    }
}
