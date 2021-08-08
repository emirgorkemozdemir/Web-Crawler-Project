using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace WebCrawlerInterface.Classes
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    public class tempSourceClass
    {

        public string source { get; set; }
        public HttpStatusCode statusCode { get; set; }
        public string description { get; set; }
        public Exception error { get; set; }
    }
}
