using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.Interfaces;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class DepartmentRepositry(AppDbcontext dbcontext) : IDepartmentRepository
    {
        private readonly AppDbcontext _dbcontext = dbcontext; // Intialize Null

        public int Add(Department Entity)
        {
            _dbcontext.Departments.Add(Entity);//added
            return _dbcontext.SaveChanges();//Update in Db
        }

        public int Delete(Department Entity)
        {
            _dbcontext.Departments.Remove(Entity);//Remove Locally
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<Department> GetAll(bool withtracking = false)
        {
            if (withtracking)
            {
                return _dbcontext.Departments.ToList();
            }
            else
            {
                return _dbcontext.Departments.AsNoTracking().ToList();
            }
        }

        public Department GetById(int id)
        {
            return _dbcontext.Departments.Find(id);
        }

        public int Update(Department Entity)
        {
           _dbcontext.Departments.Update(Entity);
           return _dbcontext.SaveChanges();
        }

    }
}
