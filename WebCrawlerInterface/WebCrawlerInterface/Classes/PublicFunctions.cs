using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogicLayer.Concrete;
using EntityLayer.Concrete;
using HtmlAgilityPack;

namespace WebCrawlerInterface.Classes
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    public class PublicFunctions
    {
       public static MainWindow referenceMW = new MainWindow();

        public static TasksForRunningURLs referenceTasksWindow = new TasksForRunningURLs();

        public static int SessionCrawledCount = 0;

        public static void updateMyStatusBox(string srMsg)
        {
            referenceMW.Dispatcher.BeginInvoke(new Action(() =>
            {
                referenceMW.myStatusBox.Items.Insert(0, $"{srMsg}\t{DateTime.Now}");
            }));
        }

        public static void updateMyEndBox(string srMsg)
        {
            referenceMW.Dispatcher.BeginInvoke(new Action(() =>
            {
                referenceMW.myEndedBox.Items.Insert(0, $"{srMsg}\t{DateTime.Now}");
            }));
        }

        public static void updateMyCrawlingBox(string srMsg)
        {
            referenceTasksWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (referenceTasksWindow.myCrawlingBox.Items.Contains($"{srMsg}"))
                {

                }
                else
                {
                    referenceTasksWindow.myCrawlingBox.Items.Insert(0, $"{srMsg}");
                }
               
            }));
        }


        public static void updateMyCrawlingBox2(string srMsg)
        {
            referenceTasksWindow.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (referenceTasksWindow.myCrawlingBox2.Items.Contains($"{srMsg}"))
                {

                }
                else
                {
                    referenceTasksWindow.myCrawlingBox2.Items.Insert(0, $"{srMsg}");
                }

            }));
        }



        //2019103005 I created try-catch and catch & logged my errors
        public static tempSourceClass extractURL(string rawURL)
        {
            tempSourceClass tempResult = new tempSourceClass();
            try
            {
                
                HttpWebRequest newRequest = (HttpWebRequest)WebRequest.Create(rawURL);
                //2019103030 using statement usage
                using (HttpWebResponse newResponse = (HttpWebResponse)newRequest.GetResponse())
                {
                    if (newResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream receive = newResponse.GetResponseStream())
                        {
                            StreamReader sr = null;
                            if (String.IsNullOrWhiteSpace(newResponse.CharacterSet))
                            {
                                sr = new StreamReader(receive);
                            }
                            else
                            {
                                sr = new StreamReader(receive, Encoding.GetEncoding(newResponse.CharacterSet));
                            }

                            tempResult.statusCode = newResponse.StatusCode;
                            tempResult.source = sr.ReadToEnd();

                            return tempResult;
                        }
                    }
                    else
                    {
                        tempResult.statusCode = newResponse.StatusCode;
                        tempResult.source = "";
                        tempResult.description = newResponse.StatusDescription;
                        
                    }
                }
            }
            catch (WebException e)
            {
                tempResult.error = e;
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    tempResult.statusCode = ((HttpWebResponse)e.Response).StatusCode;
                    tempResult.description = ((HttpWebResponse)e.Response).StatusDescription;
                }

            }
            return tempResult;

        }

       
        public static void loadCrawlingURLs(List<TableRootURL> allRootsList)
        {
            //2019103027 lock usage
            lock (PublicVariables.lockObject)
            {
                foreach (var roots in allRootsList)
                {
                    addURLsToCrawlingList(roots.RootUrl,true);
                }

                foreach (var url in PublicVariables.currentlyCrawlingUrls)
                {
                    if (url.UrlCrawled==false)
                    {
                        if (url.CrawlRetryCount>=PublicVariables.maxRetry)
                        {
                            if (url.UrlCrawlStarted.AddHours(PublicVariables.maxHours)>DateTime.Now)
                            {
                                continue;
                            }
                           
                        }
                        PublicVariables.waitingToCrawlUrls.Add(url);
                    }
                    else
                    {
                        PublicVariables.crawledUrls.Add(url);
                    }
                }
            }
        }

        //2019103003 I overloaded addURLsToCrawlingList method !
        public static void addURLsToCrawlingList(string url)
        {

            //2019103027 lock usage
            lock (PublicVariables.lockObject)
            {
                TableURL newUrl = new TableURL();
                newUrl.UrlRootSite = MainWindow.manager.BLLGetRootURL(url);
                newUrl.UrlNormalizedHashed = MainWindow.manager.BLLhashedNormalizedURL(url);
                newUrl.UrlMain = url;
                newUrl.UrlNormalized = MainWindow.manager.BLLnormalizeNewURL(url);

                MainWindow.manager.Add(newUrl);
                if (!PublicVariables.currentlyCrawlingUrls.Contains(newUrl))
                {
                  
                    PublicVariables.currentlyCrawlingUrls.Add(newUrl);
                }
            }
        }

        //2019103003 I overloaded addURLsToCrawlingList method !
        public static void addURLsToCrawlingList(string url,bool IsItForWaitings=true)
        {
            if (IsItForWaitings==true)
            {
                //2019103027 lock usage
                lock (PublicVariables.lockObject)
                {
                    TableURL newUrl = new TableURL();
                    newUrl.UrlRootSite = MainWindow.manager.BLLGetRootURL(url);
                    newUrl.UrlNormalizedHashed = MainWindow.manager.BLLhashedNormalizedURL(url);
                    newUrl.UrlMain = url;
                    newUrl.UrlNormalized = MainWindow.manager.BLLnormalizeNewURL(url);
                    MainWindow.manager.Add(newUrl);
                    if (!PublicVariables.waitingToCrawlUrls.Contains(newUrl))
                    {

                        PublicVariables.waitingToCrawlUrls.Add(newUrl);

                    }
                }
            }
        }

        //2019103003 I overloaded addURLsToCrawlingList method !
        public static void addURLsToCrawlingList(string url, bool IsItForWaitings = false,bool areTheyRoot=true)
        {
            if (areTheyRoot == true)
            {
                //2019103027 lock usage
                lock (PublicVariables.lockObject)
                {
                    TableURL newUrl = new TableURL();
                    newUrl.UrlRootSite = MainWindow.manager.BLLGetRootURL(url);
                    newUrl.UrlNormalizedHashed = MainWindow.manager.BLLhashedNormalizedURL(url);
                    newUrl.UrlMain = url;
                    newUrl.UrlNormalized = MainWindow.manager.BLLnormalizeNewURL(url);
                    MainWindow.manager.Add(newUrl);
                    if (!PublicVariables.waitingToCrawlUrls.Contains(newUrl))
                    {

                        PublicVariables.currentlyCrawlingUrls.Add(newUrl);
                 
                        CrawlURL(newUrl);
                    }
                }
            }
        }

        public static bool CheckNewURLContains(string url, bool isItForNewURLs)
        {

            //2019103027 lock usage
            lock (PublicVariables.lockObject)
            {
                if (isItForNewURLs == true)
                {
                    TableURL newUrl = new TableURL();
                    newUrl.UrlRootSite = MainWindow.manager.BLLGetRootURL(url);
                    newUrl.UrlNormalizedHashed = MainWindow.manager.BLLhashedNormalizedURL(url);
                    newUrl.UrlMain = url;
                    newUrl.UrlNormalized = MainWindow.manager.BLLnormalizeNewURL(url);
                    MainWindow.manager.Add(newUrl);
                    if (PublicVariables.crawledUrls.Contains(newUrl))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                 
                  
                }
                else
                {
                    return false;
                }
            }
        }



        public static bool CanCrawlingBeStarted()
        {
            //2019103027 lock usage
            lock (PublicVariables.runingTasks)
            {

                //to list is necessary otherwise if you make changes to the list it will give error
                foreach (var vrTask in PublicVariables.runingTasks.ToList())
                {
                    if (vrTask.Status == TaskStatus.RanToCompletion ||
                       vrTask.Status == TaskStatus.Faulted ||
                      vrTask.Status == TaskStatus.Canceled)
                    {
                       
                        PublicVariables.runingTasks.Remove(vrTask);
                        PublicFunctions.updateMyCrawlingBox2($"Link : {PublicFunctions.newCrawlingURL.UrlMain}  Task Status:{vrTask.Status} ");
                    }
                    else
                    {
                        PublicFunctions.updateMyCrawlingBox($"Link : {PublicFunctions.newCrawlingURL.UrlMain} is crawling with {PublicVariables.runingTasks.Count()} tasks !");
                    }
                }

               

                if (PublicVariables.maxTaskCount > PublicVariables.runingTasks.Count)
                {
                    return true;
                }
                   
                return false;
            }
        }

        public static  TableURL newCrawlingURL = null;
        public static void setURLsForMainCrawling()
        {

            //2019103027 lock usage
            lock (PublicVariables.waitingToCrawlUrls)
            {
                if (PublicVariables.waitingToCrawlUrls.Count==0)
                {
                    lock (PublicVariables.currentlyCrawlingUrls)
                    {
                        if (PublicVariables.currentlyCrawlingUrls.Count==0)
                        {
                            MainWindow.crawlingTimer.Stop();

                            SaveCrawlingURLs();

                            return;
                          
                        }
                    }
                }

                foreach(var newURL in PublicVariables.waitingToCrawlUrls)
                {
                    if (PublicVariables.currentlyCrawlingUrls.Contains(newURL))
                        continue;
                    newCrawlingURL = newURL;
                    break;
                }

                if (newCrawlingURL==null)
                {
                    return;
                }

                PublicVariables.waitingToCrawlUrls.Remove(newCrawlingURL);
                MainWindow.manager.BLLsetCurrentlyCrawling(newCrawlingURL);
            }
        }

        public static void SaveCrawlingURLs()
        {
            //2019103027 lock usage
            lock (PublicVariables.currentlyCrawlingUrls)
            {
                foreach (var url in PublicVariables.currentlyCrawlingUrls.ToList())
                {
                    MainWindow.manager.BLLsetWaitingForCrawl(url);
                }
            }
          
        }

        

        public static void CrawlURL(TableURL tempURL)
        {
            if (PublicVariables.IsCrawlingStopped==true)
            {
                return;
            }

            updateMyStatusBox("Started Crawling URL :\t" + tempURL.UrlMain);

            

            int retryCount = 0;

            //2019103027 lock usage
            lock (PublicVariables.lockObject)
            {
                MainWindow.manager.BLLsetStartedCrawling(tempURL);
                var myURL=  MainWindow.manager.BLLGetURLByID(tempURL);
                retryCount = myURL.CrawlRetryCount;
            }


            var myURLResult = extractURL(tempURL.UrlMain);

            //2019103034 ref keyword usage
            Interlocked.Increment(ref SessionCrawledCount);

            if (myURLResult.statusCode==HttpStatusCode.OK)
            {
                //2019103027 lock usage
                lock (PublicVariables.lockObject)
                {
                    MainWindow.manager.BLLsetEndedCrawling(tempURL,myURLResult.source);
                    updateMyEndBox($"Ended Crawling URL with no errors :{tempURL.UrlNormalized} ");
                }

                //2019103027 lock usage
                lock (PublicVariables.crawledUrls)
                {
                    PublicVariables.crawledUrls.Add(tempURL);
                    MainWindow.manager.BLLsetCrawled(tempURL);
                }

                var createdURLs = createNewURLs(myURLResult.source, tempURL.UrlMain);

                AddNewURLsToList(createdURLs);
            }
            else
            {
                if (retryCount<PublicVariables.maxRetry)
                {
                    //2019103027 lock usage
                    lock (PublicVariables.waitingToCrawlUrls)
                    {
                        PublicVariables.waitingToCrawlUrls.Add(tempURL);
                    }
                }

                TableErrorLogs newLog = new TableErrorLogs();
                newLog.LogURL = tempURL.UrlNormalized;
                newLog.LogURLErrors = $"Error Description:{myURLResult.error}";
                MainWindow.logger.Add(newLog);
                updateMyEndBox($"Error While Crawling URL :{tempURL.UrlNormalized} || Error: {myURLResult.error} ");
            }

            //2019103027 lock usage
            lock (PublicVariables.currentlyCrawlingUrls)
            {
                if (PublicVariables.currentlyCrawlingUrls.Contains(tempURL))
                {
                    PublicVariables.currentlyCrawlingUrls.Remove(tempURL);
                }
              
            }


        }

        public static int newsCount = 0;
        
      
        public static List<string> createNewURLs(string source , string sourceURL)
        {
            //2019103050 Generic list usage !
            List<string> FoundURLs = new List<string>();
        HtmlDocument newDocument = new HtmlDocument();
            newDocument.LoadHtml(source);

            var myNodes = newDocument.DocumentNode.SelectNodes("//a[@href]");

            if (myNodes !=null)
            {
                foreach (HtmlNode singleNode in myNodes)
                {
                    var hrefs = singleNode.Attributes["href"].Value.ToString();

                    var mySourceURL = new Uri(sourceURL);

                    Uri newURL;

                    if (Uri.TryCreate(mySourceURL, hrefs, out newURL))
                    {
                        string stringNewUrl = MainWindow.manager.BLLnormalizeNewURL(newURL.AbsoluteUri.ToString());
                        if (checkNewURLCanBeCrawled(sourceURL, stringNewUrl, PublicVariables.blAllowExternalLinks))
                        {
                            FoundURLs.Add(stringNewUrl);
                        }
                    }
                }
            }
            newsCount = FoundURLs.Count;
            return FoundURLs;
        }

        private static readonly List<string> notAllowedExtensionsForLinks= new List<string>
        {
          ".png",".jpg",".jpeg",".css",".js",".pdf",".docx",".doc",".epub",".xlsx"
        };

        public static bool checkNewURLCanBeCrawled(string sourceURL, string newURL,bool boolExternals)
        {
            Uri oldUrl = new Uri(sourceURL);
            Uri newUrl = new Uri(newURL);

            if (newUrl.Scheme != Uri.UriSchemeHttp && newUrl.Scheme != Uri.UriSchemeHttps)
            {
                return false;
            }

            if (boolExternals == false)
            {
                if (oldUrl.Host.ToString() != newUrl.Host.ToString())
                {
                  
                    return false;
                }
            }

            foreach (var vrExtension in notAllowedExtensionsForLinks)
            {
                if (newURL.ToLowerInvariant().EndsWith(vrExtension))
                {
                    
                    return false;
                }
            }

            return true;
        }

        public static void AddNewURLsToList(List<string> myNewURLsList)
        {
            //2019103027 lock usage
            lock (PublicVariables.crawledUrls)
            {
                foreach (var url in myNewURLsList.ToList())
                {
                    if (CheckNewURLContains(url,true)==true)
                    {
                        myNewURLsList.Remove(url);
                    }
                       
                }

                foreach (var url in myNewURLsList)
                {
                    addURLsToCrawlingList(url);
                }

                if (PublicVariables.IsCrawlingStopped==false)
                {
                    lock (PublicVariables.waitingToCrawlUrls)
                    {
                        foreach (var url in myNewURLsList)
                        {
                            addURLsToCrawlingList(url, true);
                        }
                      
                    }
                }

             
            }
        }

        public static void fillStats()
        {
            for (int i = 0; i < Statistics.statsCount; i++)
            {
                referenceMW.myStatsBox.Items.Add("a statistic will be here");
            }
        }

        public static Statistics returnMyStats()
        {
            Statistics newStats = new Statistics();
            newStats.TotalWaitingForCrawlCount = PublicVariables.waitingToCrawlUrls.Count;
            newStats.TotalCrawled = PublicVariables.crawledUrls.Count;
            newStats.NewLinksCount = newsCount;
            newStats.CrawlingCompletedThisSessionCount = SessionCrawledCount;
            newStats.CurrentlyCrawlingCount = PublicVariables.currentlyCrawlingUrls.Count;

            return newStats;
        }

    }
}
