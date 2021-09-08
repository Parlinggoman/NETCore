using Microsoft.EntityFrameworkCore;
using NETcore.Context;
using NETcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Role, int>
    {
        private readonly MyContext myContext;
        private readonly DbSet<Role> dbSet;
        public RoleRepository(MyContext myContext) : base(myContext)
        {
            this.dbSet = myContext.Set<Role>();
        }
        public int getIdByName(String name)
        {
            var getData = dbSet.Where(role => role.Name == name).FirstOrDefault();
            return getData.RoleId;
        }
    }
}
