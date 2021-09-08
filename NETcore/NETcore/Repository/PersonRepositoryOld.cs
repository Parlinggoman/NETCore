using Microsoft.EntityFrameworkCore;
using NETcore.Context;
using NETcore.Controllers;
using NETcore.Models;
using NETcore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository
{
    public class PersonRepositoryOld : IPersonRepository
    {
        private readonly MyContext myContext;

        public PersonRepositoryOld(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(string NIK)
        {
            // throw new NotImplementedException();
            var wantdelete = myContext.Persons.Find(NIK);
            if (wantdelete == null)
            {
                throw new ArgumentNullException();
            }
            myContext.Persons.Remove(wantdelete);
            var deleted = myContext.SaveChanges();
            return deleted;
        }
        
        public IEnumerable<Person> Get()
        {
            return myContext.Persons.ToList();
        }

        public Person Get(string NIK)
        {
            // throw new NotImplementedException();
            return myContext.Persons.Find(NIK);
        }

        public int Insert(Person person)
        {
            try { } catch { }
            myContext.Persons.Add(person);
            var insert = myContext.SaveChanges();
            return insert;
        }

        public int Update(Person persons)
        {                                      
            myContext.Entry(persons).State = EntityState.Modified;
            var update= myContext.SaveChanges();
            return update;
        }

        //internal static void Update(Persons persons)
        //{
        //    throw new NotImplementedException();
        //}
    }

    
}
