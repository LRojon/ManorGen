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
            InitializeComponent();
            DoubleCollection dc = new DoubleCollection()
            {
                8,
                16,
                32,
                48,
                64
            };
            this.slider.Ticks = dc;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider s = (Slider)sender;
            this.size.Content = s.Value;
            this.width.Text = (((int)(1360 / s.Value)) * s.Value).ToString();
            this.height.Text = (((int)(738 / s.Value)) * s.Value).ToString();
        }

        private void Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
