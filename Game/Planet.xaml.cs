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
    /// Interakční logika pro Planet.xaml
    /// </summary>
    public partial class Planet : UserControl
    {
        public static int Difficulty { get; set; }
        public string Type { get; set; }
        public string CommonDrop { get; set; }
        public string BossDrop { get; set; }

        //public static readonly DependencyProperty TestNameProperty = DependencyProperty.Register("Difficulty", typeof(int), typeof(Planet), new PropertyMetadata(0));

        public Planet()
        {
            InitializeComponent();
        }
    }
}
