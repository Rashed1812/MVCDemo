using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.Interfaces;
using Demo.DAL.Models;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class GenericRepository<TEntity>(AppDbcontext  _dbcontext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public void Add(TEntity Entity)
        {
            _dbcontext.Set<TEntity>().Add(Entity);//added
        }

        public void Delete(TEntity Entity)
        {
            _dbcontext.Set<TEntity>().Remove(Entity);//Remove Locally
        }

        public IEnumerable<TEntity> GetAll(bool withtracking = false)
        {
            if (withtracking)
            {
                return _dbcontext.Set<TEntity>().Where(e=>e.IsDeleted != true).ToList();
            }
            else
            {
                return _dbcontext.Set<TEntity>().Where(e => e.IsDeleted != true).AsNoTracking().ToList();
            }
        }

        public TEntity GetById(int id)
        {
            return _dbcontext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity Entity)
        {
            _dbcontext.Set<TEntity>().Update(Entity);
        }
    }
}
