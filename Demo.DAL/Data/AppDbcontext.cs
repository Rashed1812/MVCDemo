﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Configurations;
using Demo.DAL.Models.DepartmentModel;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data
{
    public class AppDbcontext(DbContextOptions<AppDbcontext> options) :IdentityDbContext<ApplicationUser>(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;database=MVC_Demo01;Trusted_connection=true;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigurations());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Run and Apply Configuration What is Running At Time
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Department> Departments { get; set; } //Create Table In Database
        public DbSet<Employee> Employees { get; set; } //Create Table In Database
    }
}
