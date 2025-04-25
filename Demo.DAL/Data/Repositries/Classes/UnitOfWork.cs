using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.Interfaces;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbcontext _appDbcontext;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        public UnitOfWork(AppDbcontext appDbcontext)
        {

            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepositry(appDbcontext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(appDbcontext));
            _appDbcontext = appDbcontext;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
        public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;
        public int SaveChanges() => _appDbcontext.SaveChanges();
    }
}
