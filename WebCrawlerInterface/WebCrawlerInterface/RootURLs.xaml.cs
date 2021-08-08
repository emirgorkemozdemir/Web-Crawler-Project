using BusinessLogicLayer.Concrete;
using EntityLayer.Concrete;
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

namespace WebCrawlerInterface
{
    /// <summary>
    /// RootURLs.xaml etkileşim mantığı
    /// </summary>
    public partial class RootURLs : Window
    {
        public RootURLs()
        {
            InitializeComponent();
        }

        RootURLManager manager = new RootURLManager();

        //2019103042 event usage
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           dgRoots.ItemsSource=manager.ListAllRoots();
        }

        //2019103042 event usage
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {

            WindowState = WindowState.Minimized;
        }

        //2019103042 event usage
        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //2019103042 event usage
        private void upbar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //2019103042 event usage
        private void btnAddRoot_Click(object sender, RoutedEventArgs e)
        {
            TableRootURL rootURL = new TableRootURL();
            rootURL.RootUrl = tboxRoot.Text;
            manager.Add(rootURL);
            dgRoots.ItemsSource = manager.ListAllRoots();
        }

        //2019103042 event usage
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
    }
}
