using ManorGen.Class;
using System.Windows;
using ManorGen.Class.Enum;
using System.Collections.Generic;
using System.Drawing;
using Point = System.Drawing.Point;

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

            /*Global.imgWidth = (int)this.img.Width;
            Global.imgHeight = (int)this.img.Height;*/
        }

        private void Gen_Click(object sender, RoutedEventArgs e)
        {
            Manor tmp = new Manor();
            this.img.Source = Global.ImageSourceFromBitmap(tmp.GetImage());
        }

        private void Conf_Click(object sender, RoutedEventArgs e)
        {
            ConfWindow conf = new ConfWindow();
            conf.ShowDialog();
        }
    }
}
