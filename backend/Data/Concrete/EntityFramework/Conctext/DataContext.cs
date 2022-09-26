using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete.EntityFramework.Conctext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

       //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
       //     base.OnConfiguring(optionsBuilder);
       //     optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=studentproje;Trusted_Connection=True;");
       // }


        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
    }
}
