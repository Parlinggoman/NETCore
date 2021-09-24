using NETcore.Context;
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


            var RegisterVMs = (from per in myContext.Persons
                               join acc in myContext.Accounts on
                               per.NIK equals acc.NIK
                               join accrole in myContext.AccountRoles on
                               acc.NIK equals accrole.NIK
                               join role in myContext.Roles on
                               accrole.RoleId equals role.RoleId
                               join prf in myContext.Profilings on
                               acc.NIK equals prf.NIK
                               join edu in myContext.Educations on
                               prf.EducationId equals edu.Id
                               select new RegisterVM
                               {
                                   NIK = per.NIK,
                                   NamaLengkap = per.FirstName + " " + per.LastName,
                                   FirstName = per.FirstName,
                                   LastName = per.LastName,
                                   PhoneNumber = per.Phone,
                                   BirthDate = per.BirthDate,
                                   Gender = per.GenderName,
                                   Salary = per.Salary,
                                   Email = per.Email,
                                   Password = acc.Password,
                                   Degree = edu.Degree,
                                   GPA = edu.GPA,
                                   UniversityId = edu.UniversityId,
                                   RoleId = accrole.RoleId

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
            if (myContext.Profilings.Find(NIK) == null)
            {
                return null;
            }


            return (from per in myContext.Persons
                    join acc in myContext.Accounts on
                    per.NIK equals acc.NIK
                    join accrole in myContext.AccountRoles on
                    acc.NIK equals accrole.NIK
                    join role in myContext.Roles on
                    accrole.RoleId equals role.RoleId
                    join prf in myContext.Profilings on
                    acc.NIK equals prf.NIK
                    join edu in myContext.Educations on
                    prf.EducationId equals edu.Id
                    select new RegisterVM
                    {
                        NIK = per.NIK,
                        NamaLengkap = per.FirstName + " " + per.LastName,
                        FirstName = per.FirstName,
                        LastName = per.LastName,
                        PhoneNumber = per.Phone,
                        BirthDate = per.BirthDate,
                        Gender = per.GenderName,
                        Salary = per.Salary,
                        Email = per.Email,
                        Password = acc.Password,
                        Degree = edu.Degree,
                        GPA = edu.GPA,
                        UniversityId = edu.UniversityId,
                        RoleId = accrole.RoleId,
                        //AccountRoles = acc.AccountRoles


                    }).Where(p => p.NIK == NIK).First();
            

        }
        public int AddNewAccountRole(string nIk, int RoleId)
        {
            //save entity accountrole
            myContext.AccountRoles.Add(new AccountRole()
            {
                NIK = nIk,
                RoleId = RoleId
            });
            return myContext.SaveChanges();

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
                //RoleId = register.RoleId
            });
            myContext.SaveChanges();

            myContext.AccountRoles.Add(new AccountRole()
            {
                NIK = register.NIK,
                RoleId = register.RoleId,
            });
            myContext.SaveChanges();

            //save entity education
            Education education = new Education(register.Degree, register.GPA,(int)register.UniversityId);
            myContext.Educations.Add(education);
            myContext.SaveChanges();

            //AccountRole accountRole = new AccountRole();
            //accountRole.NIK = register.NIK;
            //if (register.RoleId == null)
            //{
            //    accountRole.RoleId = 1;
            //}
            //accountRole.RoleId = register.RoleId;
            //myContext.AccountRoles.Add(accountRole);

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
    

