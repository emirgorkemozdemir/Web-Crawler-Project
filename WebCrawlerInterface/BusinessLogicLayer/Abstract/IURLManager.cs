using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    //2019103018 Interface usage
    public interface IURLManager
    {
        List<TableURL> BLLListCrawledUrls();
        List<TableURL> BLLListCurrentlyCrawlingUrls();
        List<TableURL> BLLListWaitingForCrawlUrls();

        string BLLnormalizeNewURL(string rawURL);

        string BLLCreateSha256(string rawString);

        string BLLGetRootURL(string tempURL);

        string BLLhashedNormalizedURL(string tempURL);

        void Add(TableURL tempURL);

        void Delete(TableURL tempURL);

        void BLLsetCrawled(TableURL tempURL);

        void BLLsetWaitingForCrawl(TableURL tempURL);

        void BLLsetCurrentlyCrawling(TableURL tempURL);

        void BLLsetStartedCrawling(TableURL tempURL);

        TableURL BLLGetURLByID(TableURL tempURL);

        void BLLsetEndedCrawling(TableURL tempURL, string myNewSource);
    }
}
