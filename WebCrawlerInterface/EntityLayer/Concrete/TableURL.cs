using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage
    //I used interface inheritance 
    public class TableURL:IDatabaseEntity
    {
        //2019103001 Used properties for my table !

        [Key]
        public int UrlID { get; set; }

        public int CrawlRetryCount = 0;

        public string UrlMain { get; set; }

        public string UrlNormalized { get; set; }

        public string UrlNormalizedHashed { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UrlCrawlStarted { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UrlCrawlEnded { get; set; }

        public string UrlRootSite { get; set; }

        public  string  UrlCrawledSource { get; set; }

        public bool UrlCurrentlyCrawling { get; set; } = false;


        public bool UrlCrawled { get; set; } = false;


        public bool UrlWaitingForCrawling { get; set; } = true;
    }
}
