using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    //2019103018 Interface usage
    public interface IRootURLManager
    {
        List<TableRootURL> ListAllRoots();

        void Add(TableRootURL tempURL);

        void Delete(TableRootURL tempURL);
    }
}
