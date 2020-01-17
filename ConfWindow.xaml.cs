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
using System.Windows.Shapes;
using ManorGen.Class;

namespace ManorGen
{
    /// <summary>
    /// Logique d'interaction pour Conf.xaml
    /// </summary>
    public partial class ConfWindow : Window
    {
        /**
         * Tools Section
         */
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        /**
         * Main Section
         */
        public ConfWindow()
        {
            Conf tmp = new Conf(Global.Conf);
            InitializeComponent();
            Global.Conf = tmp;

            DoubleCollection dc = new DoubleCollection()
            {
                8,
                16,
                32,
                48,
                64
            };
            this.slider.Ticks = dc;
            this.width.Text = Global.Conf.Width.ToString();
            this.height.Text = Global.Conf.Height.ToString();
            this.slider.Value = Global.Conf.Size;
            this.size.Content = Global.Conf.Size;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider s = (Slider)sender;
            this.size.Content = s.Value;
            this.width.Text = (((int)(1360 / s.Value)) * s.Value).ToString();
            this.height.Text = (((int)(738 / s.Value)) * s.Value).ToString();
            Global.Conf.Size = (int)s.Value;
            Global.Conf.Width = Convert.ToInt32(this.width.Text);
            Global.Conf.Height = Convert.ToInt32(this.height.Text);
        }

        private void Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name == "width")
                Global.Conf.Width = Convert.ToInt32(tb.Text);
            else if (tb.Name == "height")
                Global.Conf.Height = Convert.ToInt32(tb.Text);
        }
    }
}
