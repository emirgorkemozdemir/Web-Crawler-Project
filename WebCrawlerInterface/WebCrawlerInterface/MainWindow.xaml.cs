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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WebCrawlerInterface.Classes;

namespace WebCrawlerInterface
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //2019103006 this keyword used !
            PublicFunctions.referenceMW = this;

            PublicFunctions.fillStats();
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
            Application.Current.Shutdown();
        }

        //2019103042 event usage
        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public static  URLManager manager = new URLManager();

        public static   RootURLManager managerRoots = new RootURLManager();

        public static ErrorLogManager logger = new ErrorLogManager();

        //2019103042 event usage
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            PublicVariables.crawledUrls = manager.BLLListCrawledUrls();
            PublicVariables.currentlyCrawlingUrls = manager.BLLListCurrentlyCrawlingUrls();
            PublicVariables.waitingToCrawlUrls = manager.BLLListWaitingForCrawlUrls();

           
        }

        //2019103041 timer usage
        public static DispatcherTimer crawlingTimer = new DispatcherTimer();

        private void startTimer()
        {
           
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            dispatcherTimer.Tick += new EventHandler(updateMyStats);
            dispatcherTimer.Start();
        }


        //2019103042 event usage
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PublicVariables.IsCrawlingStopped = false;
            PublicVariables.IsCrawlingPaused = false;
            var listAllRoots = managerRoots.ListAllRoots();
            PublicFunctions.loadCrawlingURLs(listAllRoots);
            crawlingTimer.Tick += new EventHandler(StartMainCrawling);
            crawlingTimer.Interval = new TimeSpan(0, 0, 0, 0,1);
            crawlingTimer.Start();
            startTimer();

        }


        private void StartMainCrawling(object sender, EventArgs e)
        {
            if (PublicVariables.IsCrawlingStopped == true)
            {
                return;
            }
            if (PublicVariables.IsCrawlingPaused==true)
            {
                return;
            }


            for (int i = 0; i < PublicVariables.maxTaskCount; i++)
            {
                if (!PublicFunctions.CanCrawlingBeStarted())
                {

                    return;
                }

                PublicFunctions.setURLsForMainCrawling();

                //2019103027 lock usage
                lock (PublicVariables.currentlyCrawlingUrls)
                {
                    PublicVariables.currentlyCrawlingUrls.Add(PublicFunctions.newCrawlingURL);
                    manager.BLLsetCurrentlyCrawling(PublicFunctions.newCrawlingURL);
                   

                    var newTask = Task.Factory.StartNew(() =>
                    {
                        PublicFunctions.CrawlURL(PublicFunctions.newCrawlingURL);
                        
                    });

                    lock (PublicVariables.runingTasks)
                    {
                        
                        PublicVariables.runingTasks.Add(newTask);
                    }
                }
            }
        }

        //2019103042 event usage
        private void btnStopCrawling_Click(object sender, RoutedEventArgs e)
        {
            PublicVariables.IsCrawlingStopped = true;

            MessageBox.Show("Crawling is going to stop , please wait till started operations end");

            var newEndingTask = Task.Factory.StartNew(() =>
            {
                PublicFunctions.SaveCrawlingURLs();
            });

            //2019103027 lock usage
            lock (PublicVariables.waitingToCrawlUrls)
            {
                PublicVariables.waitingToCrawlUrls = new List<TableURL>();
            }
            PublicFunctions.updateMyStatusBox("All operations ended !");
        }

        //2019103042 event usage
        private void btnNewRoot_Click(object sender, RoutedEventArgs e)
        {
            RootURLs newWindow = new RootURLs();
            this.Hide();
            newWindow.Show();
        }

        //2019103042 event usage
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings windowSettings = new Settings();
            windowSettings.Show();
        }

        //2019103042 event usage
        private void btnLogs_Click(object sender, RoutedEventArgs e)
        {
            Logs windowLogs = new Logs();
            windowLogs.Show();
           
        }

        //2019103042 event usage
        private void btnSeeCrawlingTasks_Click(object sender, RoutedEventArgs e)
        {
            TasksForRunningURLs newWindow = new TasksForRunningURLs();
            newWindow.Show();
           
        }

        private void updateMyStats(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                var myStats = PublicFunctions.returnMyStats();

                var newLinks = "New links found in this session :" + myStats.NewLinksCount.ToString();

                var totalCrawled = "Total crawled links count " + myStats.TotalCrawled.ToString();

                var crawlingCompleted = "Crawling completed links count in this session: " + myStats.CrawlingCompletedThisSessionCount.ToString();

                var currentlyCrawling = "Currently crawling links count: " + myStats.CurrentlyCrawlingCount.ToString();

                var totalWaitingToCrawl = "Waiting for crawl links count:"+myStats.TotalWaitingForCrawlCount.ToString();

                myStatsBox.Items[0] = newLinks;
                myStatsBox.Items[1] = totalCrawled;
                myStatsBox.Items[2] = crawlingCompleted;
                myStatsBox.Items[3] = currentlyCrawling;
                myStatsBox.Items[4] = totalWaitingToCrawl;

            }));
        }

        //2019103042 event usage
        private void btnPauseCrawling_Click(object sender, RoutedEventArgs e)
        {
            PublicVariables.IsCrawlingPaused = true;

            MessageBox.Show("Crawling is going to pause , please wait till started operations end");
         
            PublicFunctions.updateMyStatusBox("All operations paused !");
        }
    }
}
