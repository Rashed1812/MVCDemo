using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeModel;
using Demo.DAL.Models.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DAL.Data.Configurations
{
    internal class EmployeeConfigurations :BaseEntityConfiguration<Employee> ,IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e=>e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e=>e.Gender)
                .HasConversion((EmpGender) => EmpGender.ToString(),
                 (_gender) => (Gender)Enum.Parse(typeof(Gender),_gender));
            builder.Property(e => e.EmployeeType)
                .HasConversion((EmpType) => EmpType.ToString(),
                 (_Type) => (EmployeeType)Enum.Parse(typeof(EmployeeType), _Type));
            //Calling Configuration in Base entity
            base.Configure(builder);

        }
    }
}
