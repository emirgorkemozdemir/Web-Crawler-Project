using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    //2019103010 Class inheritence  or interface intheritance usage
    public class URLDal:EfRepositoryBase<TableURL,UrlContext>
    {
       public static List<TableURL> ListCrawledUrls()
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                //2019103026 LINQ usage
                var tempList = context.TableURL.Where(i => i.UrlCrawled == true).ToList();
                return tempList;
            }
        }

        public static List<TableURL> ListCurrentlyCrawlingUrls()
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                //2019103026 LINQ usage
                var tempList = context.TableURL.Where(i => i.UrlCurrentlyCrawling == true).ToList();
                return tempList;
            }
        }

        public static List<TableURL> ListWaitingForCrawlUrls()
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                //2019103026 LINQ usage
                var tempList = context.Set<TableURL>().Where(i=>i.UrlWaitingForCrawling== true).ToList();
                return tempList;
            }
        }

        public static string normalizeNewURL(string rawURL)
        {
            return rawURL.Split('#').FirstOrDefault().ToLower(new System.Globalization.CultureInfo("en-us"));
        }

        public static string  CreateSha256(string rawString)
        {
            //2019103030 using statement usage
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawString));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

       public static string GetRootURL(string tempURL)
        {
            Uri myUri = new Uri(tempURL);
            return myUri.Host;
        }

        public static string hashedNormalizedURL(string tempURL)
        {
            return CreateSha256(normalizeNewURL(tempURL));
        }

        public static void setCrawled(TableURL tempURL)
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                var newURL = context.TableURL.Find(tempURL.UrlID);
                newURL.UrlCrawled = true;
                newURL.UrlCurrentlyCrawling = false;
                newURL.UrlWaitingForCrawling = false;
                context.SaveChanges();
            }
        }

        public static void setWaitingForCrawl(TableURL tempURL)
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                if (tempURL == null)
                {
                    return;
                }
                else
                {
                    var newURL = context.TableURL.Find(tempURL.UrlID);
                    newURL.UrlCrawled = false;
                    newURL.UrlCurrentlyCrawling = false;
                    newURL.UrlWaitingForCrawling = true;
                    context.SaveChanges();
                }
              
            }
        }

        public static void setCurrentlyCrawling(TableURL tempURL)
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                if (tempURL==null)
                {
                    return;
                }
                else
                {
                    var newURL = context.TableURL.Find(tempURL.UrlID);
                    newURL.UrlCrawled = false;
                    newURL.UrlCurrentlyCrawling = true;
                    newURL.UrlWaitingForCrawling = false;
                    context.SaveChanges();
                }
              
            }
        }

        public static void setStartedCrawling(TableURL tempURL)
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                if (tempURL == null)
                {
                    return;
                }
                else
                {
                    var newURL = context.TableURL.Find(tempURL.UrlID);
                    newURL.UrlCrawled = false;
                    newURL.UrlCurrentlyCrawling = true;
                    newURL.UrlWaitingForCrawling = false;
                    newURL.UrlCrawlStarted = DateTime.Now;
                    newURL.CrawlRetryCount++;
                    context.SaveChanges();
                }
             
            }
        }

        public static TableURL GetURLByID(TableURL tempURL)
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                var newURL = context.TableURL.Find(tempURL.UrlID);
                return newURL;
            }
        }

        public static void setEndedCrawling(TableURL tempURL,string myNewSource)
        {
            //2019103030 using statement usage
            using (UrlContext context = new UrlContext())
            {
                var newURL = context.TableURL.Find(tempURL.UrlID);
                newURL.UrlCrawled = false;
                newURL.UrlCurrentlyCrawling = true;
                newURL.UrlWaitingForCrawling = false;
                newURL.UrlCrawlEnded = DateTime.Now;
                newURL.UrlCrawledSource = myNewSource;
                context.SaveChanges();
            }
        }
    }
}
