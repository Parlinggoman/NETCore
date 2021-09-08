using NETcore.Context;

using NETcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository.Data
{
    public class UniversityRepository : GeneralRepository<MyContext,University,int>
    {
        public UniversityRepository(MyContext myContext) : base(myContext)
        { 

        }
    }
}
