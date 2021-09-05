using NETcore.Context;
using NETcore.Model;
using NETcore.ViewModel;
using NETcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NETcore.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, string>
    {
        private readonly MyContext myContext;
        private readonly DbSet<Person> dbSet;
        public PersonRepository(MyContext myContext) : base(myContext)
        {

            this.myContext = myContext;
            dbSet = myContext.Set<Person>();
        }
        public IEnumerable<RegisterVM> RegisterVMs()
        {


            var RegisterVMs = (from p in myContext.Persons
                               join a in myContext.Accounts on p.NIK equals a.NIK
                               join rl in myContext.Roles on a.RoleId equals rl.RoleId
                               join pf in myContext.Profilings on a.NIK equals pf.NIK
                               join e in myContext.Educations on pf.EducationId equals e.Id
                               //join u in myContext.University on e.UniversityId equals u.UniversityId
                               select new RegisterVM
                               {
                                     NIK = p.NIK,
                                   NamaLengkap = p.FirstName + " " + p.LastName,
                                   FirstName = p.FirstName,
                                   LastName = p.LastName,
                                   PhoneNumber = p.Phone,
                                   BirthDate = p.BirthDate,
                                   Gender = (int)p.GenderName,
                                   Salary = p.Salary,
                                   Email = p.Email,
                                   Password = a.Password,
                                   Degree = e.Degree,
                                   GPA = e.GPA,
                                   UniversityId=e.UniversityId,
                                   RoleId=rl.RoleId


                               }).ToList();
            if (RegisterVMs.Count == 0)
            {
                return null;
            }
            return RegisterVMs.ToList();

            //  return RegisterVMs;
        }

       

        public RegisterVM GetRegister(string NIK)
        {
            if (dbSet.Find(NIK) == null)
            {
                return null;

            }
            else
            {
                return (from p in myContext.Persons
                        join a in myContext.Accounts on p.NIK equals a.NIK
                        join rl in myContext.Roles on a.RoleId equals rl.RoleId
                        join pf in myContext.Profilings on a.NIK equals pf.NIK
                        join e in myContext.Educations on pf.EducationId equals e.Id
                        join u in myContext.University on e.UniversityId equals u.UniversityId
                        select new RegisterVM
                        {

                            //        )
                            //}
                            //var RegisterVMs = (from p in myContext.Persons
                            //                   join a in myContext.Accounts on p.NIK equals a.NIK
                            //                   join pf in myContext.Profilings on a.NIK equals pf.NIK
                            //                   join e in myContext.Educations on pf.EducationId equals e.Id
                            //                   select new RegisterVM
                            //                   {
                            NIK = p.NIK,
                            NamaLengkap = p.FirstName + " " + p.LastName,
                            //FirstName = p.FirstName,
                            //LastName = p.LastName,
                            PhoneNumber = p.Phone,
                            BirthDate = p.BirthDate,
                            Gender = (int)p.GenderName,
                            Salary = p.Salary,
                            Email = p.Email,
                            Password = a.Password,
                            Degree = e.Degree,
                            GPA = e.GPA,
                            UniversityId=e.UniversityId,
                            RoleId=rl.RoleId


                        }).Where(p => p.NIK == NIK).First();
            }

        }

      
        public int  InsertRegister(RegisterVM register)
        {
            myContext.Persons.Add(new Person()
                {
                NIK = register.NIK,
                    FirstName = register.FirstName,
                    LastName= register.LastName,
                    Phone = register.PhoneNumber,
                    BirthDate=register.BirthDate,
                    GenderName = (Person.Gender)register.Gender,
                    Salary = register.Salary,
                    Email=register.Email,
                });
            myContext.SaveChanges();


            myContext.Accounts.Add(new Account()
            {
                NIK = register.NIK,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password, BCrypt.Net.BCrypt.GenerateSalt(12)),
                RoleId = register.RoleId
            });
            myContext.SaveChanges();

     
            Education education = new Education(register.Degree, register.GPA,(int)register.UniversityId);
            myContext.Educations.Add(education);
            myContext.SaveChanges();

            myContext.Profilings.Add(new Profiling()
            {
                NIK = register.NIK,
                EducationId = education.Id,
            });
            return myContext.SaveChanges();
        }
        public string ValidationUnique(string nik, string email, string phone)
        {
            if (dbSet.Find(nik) != null)
            {
                return "NIK sudah ada";
            }

            if (dbSet.Where(per => per.Email == email).Count() > 0)
            {
                return "Email sudah ada";
            }

            if (dbSet.Where(per => per.Phone == phone).Count() > 0)
            {
                return "Nomor hp sudah ada";
            }

            return "1";
        }
    }
 }
    

