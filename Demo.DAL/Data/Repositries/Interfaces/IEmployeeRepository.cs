using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.DAL.Data.Repositries.Interfaces
{
    public interface IEmployeeRepository :IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeeByName(string name);
    }
}
