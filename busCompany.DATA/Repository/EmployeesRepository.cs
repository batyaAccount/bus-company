using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class EmployeesRepository :Repository<Employee>, IEmployeeRepository
    {
        public readonly DataContext _context;
        public EmployeesRepository(DataContext context):base(context) 
        {
            _context = context;
        }
      
        public bool Update(int id, Employee employee)
        {
         
            Employee employee1 = GetById(id);

            employee1.Salary = employee.Salary;
            employee1.Tz = employee.Tz;
            employee1.Address = employee.Address;
            employee1.Name = employee.Name;
            employee1.AmountOfHours = employee.AmountOfHours;
            employee1.StartDate = employee.StartDate;
            employee1.WorkType = employee.WorkType;
            employee1.PhoneNumber = employee.PhoneNumber;
            return true;
        }
        public int indexOf(int id)
        {
            return Get().ToList().FindIndex(b => b.Id == id);
        }
    }
}
