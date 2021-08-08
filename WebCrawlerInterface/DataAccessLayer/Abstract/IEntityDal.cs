using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //2019103018 Interface usage
    //Generic interface usage ! (we do not have any code about this on pdf)
    public interface IEntityDal<T> where T: class , IDatabaseEntity , new()
    {
        void Add(T tempEntity);

        void Delete(T tempEntity);

        List<T> ListAll();
    }
}
