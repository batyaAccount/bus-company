using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.Core.IRepository
{
    public interface IEmployeeRepository
    {
        public int indexOf(int id);

        public IEnumerable<Employee> GetEmployees();
        public Employee getByIdEmployees(int id);
        public bool Add(Employee employee);
        public bool Update(int id, Employee employee);
        public bool DeleteEmployees(int id);
    }
}
