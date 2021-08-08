using DataAccessLayer.Abstract;
using EntityLayer.Abstract;
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
    public class EfRepositoryBase<Tentity, Tcontext> : IEntityDal<Tentity> where Tentity : class, IDatabaseEntity, new()
         where Tcontext : DbContext, new()
    {
        public void Add(Tentity tempEntity)
        {
            //2019103030 using statement usage
            using (Tcontext context = new Tcontext())
            {
                var addEntity = context.Entry(tempEntity);

                addEntity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public void Delete(Tentity tempEntity)
        {
            //2019103030 using statement usage
            using (Tcontext context = new Tcontext())
            {
                var deletingEntity = context.Entry(tempEntity);

                deletingEntity.State = EntityState.Deleted;

                context.SaveChanges();
            }
        }

        public List<Tentity> ListAll()
        {
            //2019103030 using statement usage
            using (Tcontext context = new Tcontext())
            {
                return context.Set<Tentity>().ToList();
            }
        }
    }
}
