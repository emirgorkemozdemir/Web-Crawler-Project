using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    //2019103010 Class inheritence  or interface intheritance usage
    public class UrlContext:DbContext
    {
        //2019103012 base keyword usage
        public UrlContext() : base("name=UrlContext")
        {

        }
        public DbSet<TableURL> TableURL { get; set; }
        public DbSet<TableRootURL> TableRootURL { get; set; }
        public DbSet<TableErrorLogs> TableErrorLogs { get; set; }
    }
}
