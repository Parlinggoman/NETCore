using Microsoft.EntityFrameworkCore;
using NETcore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETcore.Context
{
    public class MyContext : DbContext //merupakan gateway aplikasi dengan database
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { 

        }
        public DbSet<Person> Persons { get; set; } // <person> bebas nanti ditambah using NETcore.Model
        public DbSet<Education> Educations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<ResetPassword> ResetPasswords { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(account=> account.Account)
                .WithOne(person => person.Person)
                .HasForeignKey<Account>(account => account.NIK);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Profiling)
                .WithOne(pf => pf.Account)
                .HasForeignKey<Profiling>(a => a.NIK);
            modelBuilder.Entity<Education>()
              .HasMany(e => e.Profiling)
              .WithOne(pf => pf.Educations);
            modelBuilder.Entity<University>()
               .HasMany(u => u.Education)
               .WithOne(e => e.University);

        }
        
    }
}
