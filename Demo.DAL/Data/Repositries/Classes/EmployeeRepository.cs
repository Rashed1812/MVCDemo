using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.Interfaces;
using Demo.DAL.Models.EmployeeModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class EmployeeRepository(AppDbcontext _dbcontext) : GenericRepository<Employee>(_dbcontext), IEmployeeRepository
    {
       
    }
}
