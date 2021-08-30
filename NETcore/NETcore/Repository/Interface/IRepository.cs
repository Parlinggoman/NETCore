using NETcore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository.Interface
{

    public  interface IRepository<Entity,Key> where Entity: class
    {
        IEnumerable<Entity> Get();
        Person Get(Key key);
        int Insert(Entity entity);
        int Update(Entity entity); 
        int Delete(Key key);
    }
}
