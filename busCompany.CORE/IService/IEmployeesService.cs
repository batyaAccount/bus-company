﻿using busCompany.API.PostEntity;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IEmployeesService
    {
        public IEnumerable<EmployeeDto> GetAll();
        public EmployeeDto GetEmployee(int id);
        public EmployeeDto Add(EmployeeDto employee);
        public bool Update(int id, EmployeeDto employee);
        public bool DeleteOne(int id);
    }
}
