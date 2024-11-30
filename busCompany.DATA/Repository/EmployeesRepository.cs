using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class EmployeesRepository : IEmployeeRepository
    {
        public readonly DataContext _context;
        public EmployeesRepository(DataContext context)
        {
            _context = context;
        }
        public List<Employee> GetEmployees() { return _context.Employees; }
        public Employee getByIdEmployees(int id)
        {
            return _context.Employees.Find(z => z.Id == id);

        }
        public bool Add(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(int id, Employee employee)
        {
            Employee employee1 = _context.Employees.Find(b => b.Id == id);
            if (employee1 == null)
                return false;
            DeleteEmployees(id);
            employee1.Address = employee.Address;
            employee1.Id = id;
            employee1.Name = employee.Name;
            employee1.StartDate = employee.StartDate;
            employee1.AmountOfHours = employee.AmountOfHours;
            employee1.PhoneNumber = employee.PhoneNumber;
            employee1.Salary = employee.Salary;
            employee1.Tz = employee.Tz;
            employee1.WorkType = employee.WorkType;
            if (Add(employee1))
                return true;
            return false;

        }
        public bool DeleteEmployees(int id)
        {

            List<Employee> l = _context.Employees;

            Employee employeeToDelete = l.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

    }
}
