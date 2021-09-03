using Microsoft.EntityFrameworkCore;

using NETcore.Context;
using NETcore.Model;
using NETcore.Repository.Interface;
using NETcore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
      where Entity : class
      where Context : MyContext


    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> dbSet;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            dbSet = myContext.Set<Entity>();

        }
        public int Delete(Key key)
        {

            var wantDelete = dbSet.Find(key);
            if (wantDelete == null)
            {
                throw new ArgumentNullException();
            }
            dbSet.Remove(wantDelete);
            var delete = myContext.SaveChanges();
            return delete;
        }

        public IEnumerable<Entity> Get()
        {
            return dbSet.ToList();
        }
        public Entity Get(Key key)
        {
            return dbSet.Find(key);
        }

        //public Person Get(Key key)
        //{
        //    throw new NotImplementedException();
        //}

        public int Insert(Entity entity)
        {
            dbSet.Add(entity);
            var insert = myContext.SaveChanges();
            return insert;
        }

       

        public int Update(Entity entity)
        {
            myContext.Entry(entity).State = EntityState.Modified;
            var update = myContext.SaveChanges();
            return update;
        }

        
    }
}
