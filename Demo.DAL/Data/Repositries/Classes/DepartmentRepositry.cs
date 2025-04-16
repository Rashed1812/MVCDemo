﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DAL.Data.Repositries.Interfaces;
using Demo.DAL.Models.DepartmentModel;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Data.Repositries.Classes
{
    public class DepartmentRepositry(AppDbcontext _dbcontext) :GenericRepository<Department>(_dbcontext) ,IDepartmentRepository
    {

    }
}
