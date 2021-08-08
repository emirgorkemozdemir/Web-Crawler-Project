using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawlerInterface.Classes
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    public class Statistics
    {
        public static int statsCount = 5;

        public int CurrentlyCrawlingCount { get; set; }
        public int CrawlingCompletedThisSessionCount { get; set; }
        public int TotalCrawled { get; set; }
        public int NewLinksCount { get; set; }
        public int TotalWaitingForCrawlCount { get; set; }
    }
}
