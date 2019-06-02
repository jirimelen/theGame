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
    /// Interakční logika pro MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Frame frame;

        public MainMenu()
        {
            InitializeComponent();
        }
        public MainMenu(Frame mainFrame) : this()
        {
            frame = mainFrame;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Garage(frame));
        }
    }
}
