using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Models;

namespace Demo.DAL.Data.Repositries.Interfaces
{
    //Create Methods
    public interface IDepartmentRepository
    {
        //Get All
        IEnumerable<Department> GetAll(bool withtracking = false);
        //GetById
        Department GetById(int id);
        //Update
        int Update (Department Entity);
        //Delete
        int Delete (Department Entity);
        //Insert
        int Add (Department Entity);
        //Return int To Check from DB How Many Row is Efficted 
    }
}
