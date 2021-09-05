using NETcore.Context;
using NETcore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository.Data
{
    
    public class ProfilingRepository : GeneralRepository<MyContext,Profiling,string>
    {
        public ProfilingRepository(MyContext myContext) : base(myContext)
        { 
        }
    }
}
