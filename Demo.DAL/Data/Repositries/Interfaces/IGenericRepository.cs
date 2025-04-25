using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.DAL.Data.Repositries.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll(bool withtracking = false);
        TEntity? GetById(int id);
        void Add(TEntity Entity);
        void Update(TEntity Entity);
        void Delete(TEntity Entity);
    }
}
