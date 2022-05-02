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

namespace AIPO74_HFT_2021221.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void JumpToCrudButton(object sender, RoutedEventArgs e)
        {
            Crud crud = new Crud();
            crud.Show();
            Close();
        }

        private void ExitMainButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToNoncrudForm(object sender, RoutedEventArgs e)
        {
            NonCrud nonCrud = new NonCrud();
            nonCrud.Show();
            Close();
        }
    }
}
