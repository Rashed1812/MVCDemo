using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data
{
    public class AppDbcontext :DbContext
    {
        public AppDbcontext(DbContextOptions <AppDbcontext> options):base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;database=MVC_Demo01;Trusted_connection=true;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Run and Apply Configuration What is Running At Time
        }
        public DbSet<Department> Departments { get; set; } //Create Rable In Database
    }
}
