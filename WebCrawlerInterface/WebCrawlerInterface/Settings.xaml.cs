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
using System.Windows.Shapes;
using WebCrawlerInterface.Classes;

namespace WebCrawlerInterface
{
    /// <summary>
    /// Settings.xaml etkileşim mantığı
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        //2019103042 event usage
        private void upbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //2019103042 event usage
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //2019103042 event usage
        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //2019103042 event usage
        private void btnMaxTasks_Click(object sender, RoutedEventArgs e)
        {
            int newMaxConcurrentTasks = 0;
            Int32.TryParse(tboxMaxTasks.Text, out newMaxConcurrentTasks);
            if (newMaxConcurrentTasks > 0)
            {
                PublicVariables.maxTaskCount = newMaxConcurrentTasks;
            }
            else
            {
                MessageBox.Show("Max tasks cannot be below zero");
            }
        }

        //2019103042 event usage
        private void cboxExtarnals_Click(object sender, RoutedEventArgs e)
        {
            if (cboxExtarnals.IsChecked==true)
            {
                PublicVariables.blAllowExternalLinks = true;
            }
            else
            {
                PublicVariables.blAllowExternalLinks = false;
            }
              
        }
    }
}
