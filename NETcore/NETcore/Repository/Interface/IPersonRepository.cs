using NETcore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Repository.Interface
{
  interface IPersonRepository
    {
        IEnumerable<Person> Get();
        Person Get(string NIK);
        int Insert(Person person);
        int Update( Person person); // klo mau update dapat dilakukan dari id/NIK jadi cukup masukin variabel id nya saja/primary key
        int Delete(string NIK); 
    }
}
