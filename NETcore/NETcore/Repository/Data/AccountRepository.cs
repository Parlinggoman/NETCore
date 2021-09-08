using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NETcore.Context;
using NETcore.Models;
using NETcore.ViewModel;
using System.Linq;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace NETcore.Repository.Data
{

    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        private readonly DbSet<Account> dbSet;

        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            dbSet = myContext.Set<Account>();
        }
        public IEnumerable<LoginVM> GetLoginVMs()
        {
            var getLoginVMs = (from p in myContext.Persons
                               join a in myContext.Accounts on
                               p.NIK equals a.NIK
                               select new LoginVM
                               {
                                 // NIK=p.NIK,
                                   Email = p.NIK,
                                   Password = a.Password
                               }).ToList();


            if (getLoginVMs.Count == 0)
            {
                return null;
            }
            return getLoginVMs.ToList();
        }

        public LoginVM Login(LoginVM login)
        {
            if (myContext.Persons.Where(p => p.Email == login.Email).Count() <= 0)
            {
                return null;
            }
            return (from p in myContext.Persons
                    join a in myContext.Accounts
                    on p.NIK equals a.NIK
                    select new LoginVM
                    {
                        NIK=p.NIK,
                        Email = p.Email,
                        Password = a.Password,
                    }
         ).Where(per => per.Email == login.Email).First();
        }
        public LoginVM FindByEmail(string email)
        {
            var data = myContext.Persons.Where(p => p.Email == email);
            if (data.Count() > 0)
            {
                return (from p in myContext.Persons
                        join a in myContext.Accounts on
                        p.NIK equals a.NIK
                        select new LoginVM
                        {
                            NIK = p.NIK,
                            Email = p.Email,
                            Password = a.Password
                        }).Where(p => p.Email == email).First();
            }

            return null;
        }
        public IEnumerable<RoleVM> getRole(string nIK)
        {
            var RoleVMs = (from acc in myContext.Accounts
                           join ar in myContext.AccountRoles on
                           acc.NIK equals ar.NIK
                           join r in myContext.Roles on
                            ar.RoleId equals r.RoleId
                           select new RoleVM
                           {
                               NIK = acc.NIK,
                               RoleName = r.Name
                           }).Where(ar => ar.NIK == nIK);

            return RoleVMs.ToList();

        }


        public bool SaveResetPassword(string email, int otp, string nik)
        {
            var resetPassword = new ResetPassword()
            {
                Email = email,
                OTP = otp.ToString(),
                NIK = nik,
                CreatedAt = DateTime.Now
            };
            myContext.ResetPasswords.Add(resetPassword);
            myContext.SaveChanges();
            return true;
        }

        //internal object GeneratePasswordResetToken()
        //{
        //    throw new NotImplementedException();
        //}

        public string ResetPassword(string nik, string otp, string newPassword)
        {
            // check otp
            var dataReset = myContext.ResetPasswords.Where(o => o.OTP == otp.ToString()).FirstOrDefault();
            if (dataReset == null)
            {
                return "Kode OTP Salah";
            }

            //check expired kode OTP
            if (dataReset.CreatedAt.AddMinutes(15) < DateTime.Now)
            {
                return "Kode OTP sudah expired, silahkan generate ulang OTP baru";
            };

            //reset password
            dbSet.Update(new Account()
            {
                NIK = nik,
                Password = BCrypt.Net.BCrypt.HashPassword(newPassword, BCrypt.Net.BCrypt.GenerateSalt(12))
            });
            myContext.SaveChanges();

            myContext.ResetPasswords.Remove(dataReset);
            myContext.SaveChanges();

            return "Password Berhasil di update";
        }

        public bool ResetPassword(string nik, string newPassword)
        {
            //reset password
            dbSet.Update(new Account()
            {
                NIK = nik,
                Password = BCrypt.Net.BCrypt.HashPassword(newPassword, BCrypt.Net.BCrypt.GenerateSalt(12))
            });
            myContext.SaveChanges();

            return true;
        }

        public string GetRandomAlphanumericString(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            var result = new char[length];
            using (var cryptoProvider = new RNGCryptoServiceProvider())
            {
                cryptoProvider.GetBytes(bytes);
            }
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
    }
}
