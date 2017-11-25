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

namespace Rasp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var newWindow = new Window1();
            //newWindow.Show();
        }
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            if ((txtServidor.Text != "" && txtPorta.Text != ""))
            {
                var newWindow = new Window1();
                newWindow.Show();
                this.Hide();
            }
            else MessageBox.Show("Insirar algum valor nos Campos");
        }
    }
}
