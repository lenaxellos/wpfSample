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

namespace wpfSample
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLayout01_Click(object sender, RoutedEventArgs e)
        {
            Layout01 layout01 = new Layout01();
            layout01.Show();
        }

        private void BtnMaterialDesign_Click(object sender, RoutedEventArgs e)
        {
            MaterialDesign materialDesign = new MaterialDesign();
            materialDesign.Show();
        }

        private void BtnWeather_Click(object sender, RoutedEventArgs e)
        {
            Weather weather = new Weather();
            weather.Show();
        }

        private void BtnBinding_Click(object sender, RoutedEventArgs e)
        {
            WpfBinding wpfbinding = new WpfBinding();
            wpfbinding.Show();
        }

        private void BtnResource_Click(object sender, RoutedEventArgs e)
        {
            ResourceStyle resourceStyle = new ResourceStyle();
            resourceStyle.Show();
        }
    }
}
