using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IEmployeesService
    {
        public List<Employee> GetAll();
        public Employee GetEmployee(int id);
        public bool Add(Employee employee);
        public bool Update(int id, Employee employee);
        public bool DeleteOne(int id);
    }
}
