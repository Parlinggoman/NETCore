﻿using NETcore.Context;
using NETcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository.Data
{
    //public class PersonRepository : GeneralRepository<MyContext, Person, string>
    //{
    //    public PersonRepository(MyContext myContext) : base(myContext)
    //    {

    //    }
    public class EducationRepository : GeneralRepository<MyContext,Education,int>
    {
        public EducationRepository(MyContext myContext) : base(myContext)
        { 
        }
    }
}
