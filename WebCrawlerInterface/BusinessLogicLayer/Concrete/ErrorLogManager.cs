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
    public class ErrorLogManager : IErrorLogManager
    {
        ErrorLogDal logger = new ErrorLogDal();
        public void Add(TableErrorLogs tempURL)
        {
            logger.Add(tempURL);
        }

        public void Delete(TableErrorLogs tempURL)
        {
            logger.Delete(tempURL);
        }

        public List<TableErrorLogs> ListAllLogs()
        {
            return logger.ListAll();
        }
    }
}
