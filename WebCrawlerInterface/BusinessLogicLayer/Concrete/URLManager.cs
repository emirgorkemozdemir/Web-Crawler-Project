using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    public class URLManager : IURLManager
    {
        URLDal dalURL = new URLDal();

        public void Add(TableURL tempURL)
        {
            dalURL.Add(tempURL);
        }

        public string BLLCreateSha256(string rawString)
        {
          return  URLDal.CreateSha256(rawString);
        }

        public string BLLGetRootURL(string tempURL)
        {
            return URLDal.GetRootURL(tempURL);
        }

        public string BLLhashedNormalizedURL(string tempURL)
        {
            return URLDal.hashedNormalizedURL(tempURL);
        }

        public List<TableURL> BLLListCrawledUrls()
        {
            return URLDal.ListCrawledUrls();
        }

        public List<TableURL> BLLListCurrentlyCrawlingUrls()
        {
            return URLDal.ListCurrentlyCrawlingUrls();
        }

        public List<TableURL> BLLListWaitingForCrawlUrls()
        {
            return URLDal.ListWaitingForCrawlUrls();
        }

        public string BLLnormalizeNewURL(string rawURL)
        {
            return URLDal.normalizeNewURL(rawURL);
        }

        public void BLLsetCrawled(TableURL tempURL)
        {
            URLDal.setCrawled(tempURL);
        }

        public void BLLsetCurrentlyCrawling(TableURL tempURL)
        {
            URLDal.setCurrentlyCrawling(tempURL);
        }

        public void BLLsetWaitingForCrawl(TableURL tempURL)
        {
            URLDal.setWaitingForCrawl(tempURL);
        }

        public void Delete(TableURL tempURL)
        {
            dalURL.Delete(tempURL);
        }

        public void BLLsetStartedCrawling(TableURL tempURL)
        {
            URLDal.setStartedCrawling(tempURL);
        }

        public TableURL BLLGetURLByID(TableURL tempURL)
        {
          return  URLDal.GetURLByID(tempURL);
        }

        public void BLLsetEndedCrawling(TableURL tempURL, string myNewSource)
        {
            URLDal.setEndedCrawling(tempURL, myNewSource);
        }
    }
}
