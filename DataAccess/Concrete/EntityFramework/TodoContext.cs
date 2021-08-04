using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: Db tabloları ile proje classlarını bağlamak
   public class TodoContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoDb;Trusted_Connection=true");
        }

        public DbSet<Todo> ToDos { get; set; }
    }
}
