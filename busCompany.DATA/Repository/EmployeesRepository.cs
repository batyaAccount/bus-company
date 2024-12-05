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
    public class EmployeesRepository : IEmployeeRepository
    {
        public readonly DataContext _context;
        public EmployeesRepository(DataContext context)
        {
            _context = context;
        }
        public List<Employee> GetEmployees() { return _context.Employees.ToList(); }
        public Employee getByIdEmployees(int id)
        {
            return _context.Employees.ToList().Find(z => z.Id == id);

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
         
            //The validate checking was done in the service
            Employee employee1 = _context.Employees.ToList().Find(b => b.Id == id);

            _ = employee.Salary != 0 && employee.Salary != employee1.Salary ?
             employee1.Salary = employee.Salary : employee1.Salary = employee1.Salary;

            _ = employee.Tz != null && employee.Tz != employee1.Tz ?
       employee1.Tz = employee.Tz : employee1.Tz = employee1.Tz;

            _ = employee.Address != null && employee.Address != employee1.Address ?
       employee1.Address = employee.Address : employee1.Address = employee1.Address;

            _ = employee.Name != null && employee.Name != employee1.Name ?
              employee1.Name = employee.Name : employee1.Name = employee1.Name;

            _ = employee.AmountOfHours != 0 && employee.AmountOfHours != employee1.AmountOfHours ?
            employee1.AmountOfHours = employee.AmountOfHours : employee1.AmountOfHours = employee1.AmountOfHours;

            _ = employee.StartDate != DateTime.MinValue && employee.StartDate != employee1.StartDate ?
            employee1.StartDate = employee.StartDate : employee1.StartDate = employee1.StartDate;

            _ = employee.WorkType !=null && employee.WorkType != employee1.WorkType ?
            employee1.WorkType = employee.WorkType : employee1.WorkType = employee1.WorkType;

            _ = employee.PhoneNumber != null && employee.PhoneNumber != employee1.PhoneNumber ?
            employee1.PhoneNumber = employee.PhoneNumber : employee1.PhoneNumber = employee1.PhoneNumber;

           _context.SaveChanges();
            return true;
        }
        public bool DeleteEmployees(int id)
        {

            List<Employee> l = _context.Employees.ToList();

            Employee employeeToDelete = l.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        public int indexOf(int id)
        {
            return _context.Employees.ToList().FindIndex(b => b.Id == id);
        }
    }
}
