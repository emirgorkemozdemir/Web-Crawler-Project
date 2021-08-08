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
    public class RootURLManager : IRootURLManager
    {
        RootURLDal rootURLDal = new RootURLDal();

        public void Add(TableRootURL tempURL)
        {
            rootURLDal.Add(tempURL);
        }

        public List<TableRootURL> ListAllRoots()
        {
            return rootURLDal.ListAll();
        }

        public void Delete(TableRootURL tempURL)
        {
            rootURLDal.Delete(tempURL);
        }
    }
}
