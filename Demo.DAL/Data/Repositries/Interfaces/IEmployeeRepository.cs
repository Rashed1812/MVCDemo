using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models.EmployeeModel;

namespace Demo.DAL.Data.Repositries.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll(bool withtracking = false);
        Employee? GetById(int id);
        int Add(Employee Employee);
        int Update(Employee Employee);
        int Delete(Employee Employee);
    }
}
