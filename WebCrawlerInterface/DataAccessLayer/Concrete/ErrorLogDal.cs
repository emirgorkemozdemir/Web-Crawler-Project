using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    //2019103008 non-static class usage
    //2019103009  Public and private class, variable and method usage 
    //2019103010 Class inheritence  or interface intheritance usage
    public class ErrorLogDal : EfRepositoryBase<TableErrorLogs, UrlContext>
    {

    }
}
