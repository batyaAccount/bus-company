﻿using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;

namespace busCompany.SERVICE.Service
{
    public class EmployeesService : IEmployeesService
    {
        readonly IRepositoryMamager _repositoryMamager;
        readonly IEmployeeRepository _employeeRepository;
        public EmployeesService(IRepositoryMamager repositoryMamager,IEmployeeRepository employeeRepository)
        {
            _repositoryMamager = repositoryMamager;
            _employeeRepository = employeeRepository;

        }
        public Employee Add(Employee employee)
        {
            if (GetEmployee(employee.Id) != null)
                return null;
            if (employee.PhoneNumber.Length != 10 || CheckIDNo(employee.Tz) == false)
                return null;
            _repositoryMamager.Employees.Add(employee);
            _repositoryMamager.Save();
            return employee;
        }

        public bool DeleteOne(int id)
        {
            if(_employeeRepository.indexOf(id) == -1)
                return false;
            _employeeRepository.Delete(id);
            _repositoryMamager.Save();
            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.Get().ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public bool Update(int id, Employee employee)
        {

            if (GetAll().Count() == 0)
                return false;
            if (_employeeRepository.indexOf(id) == -1)
                return false;
            if (employee.Tz != null && !CheckIDNo(employee.Tz) || employee.PhoneNumber != null && employee.PhoneNumber.Length != 10)
                return false;

            bool flag = _employeeRepository.Update(id, employee);
            if (flag)
                _repositoryMamager.Save();
            return flag;
        }
        static bool CheckIDNo(string strID)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;

            if (strID == null)
                return false;

            strID = strID.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }

    }
}