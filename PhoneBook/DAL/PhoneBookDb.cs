using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PhoneBook.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PhoneBook.DAL
{
    public class PhoneBookDb:DbContext
    {
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<Number> Numbers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}