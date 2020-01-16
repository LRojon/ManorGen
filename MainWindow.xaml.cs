using ManorGen.Class;
using System.Windows;
using ManorGen.Class.Enum;
using System.Collections.Generic;

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

            Global.imgWidth = (int)this.img.Width;
            Global.imgHeight = (int)this.img.Height;
        }

        private void Gen_Click(object sender, RoutedEventArgs e)
        {
            this.img.Source = Global.ImageSourceFromBitmap(new Tile()
            {
                Door = Door.None,
                Walls = new List<Wall>()
                {
                    Wall.North,
                    Wall.East,
                    Wall.South,
                    Wall.West
                }
            }.GetTileImage());
        }

        private void Conf_Click(object sender, RoutedEventArgs e)
        {
            Global.Conf = Global.Conf;
            ConfWindow conf = new ConfWindow();
            conf.ShowDialog();
        }
    }
}
