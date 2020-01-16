using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using ManorGen.Class;

namespace ManorGen
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /**
         * Declaration Section
         */

        /**
         * Main Section
         */
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Conf_Click(object sender, RoutedEventArgs e)
        {
            Global.Manor.Conf = Global.Manor.Conf;
            ConfWindow conf = new ConfWindow();
            conf.ShowDialog();
        }
    }
}
