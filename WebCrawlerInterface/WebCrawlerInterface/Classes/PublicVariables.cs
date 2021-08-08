using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerInterface.Classes
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    public class PublicVariables
    {
        public static int maxTaskCount = 10;
        public static int maxHours = 24;
        public static int maxRetry = 3;

        public static bool IsCrawlingStopped = false;
        public static bool IsCrawlingPaused = false;
        public static bool blAllowExternalLinks = false;


        //2019103050 Generic list usage !
        public static List<TableRootURL> rootURLs = new List<TableRootURL>();
        public static List<TableURL> crawledUrls = new List<TableURL>();
        public static List<TableURL> waitingToCrawlUrls = new List<TableURL>();
        public static List<TableURL> currentlyCrawlingUrls = new List<TableURL>();

        public static object lockObject= new object();

        public static List<Task> runingTasks = new List<Task>();
    }
}
