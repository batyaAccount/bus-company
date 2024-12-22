using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;

namespace busCompany.SERVICE.Service
{
    public class EmployeesService : IEmployeesService
    {
        readonly IRepositoryMamager _employeeRepository;
        public EmployeesService(IRepositoryMamager employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool Add(Employee employee)
        {
            if (GetEmployee(employee.Id) != null)
                return false;
            if (employee.PhoneNumber.Length != 10 || CheckIDNo(employee.Tz) == false)
                return false;
            bool flag = _employeeRepository.Employees.Add(employee);
            if (flag)
                _employeeRepository.Save();
            return flag;
        }

        public bool DeleteOne(int id)
        {
            bool flag = _employeeRepository.Employees.DeleteEmployees(id);
            if (flag)
                _employeeRepository.Save();
            return flag;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.Employees.GetEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.Employees.getByIdEmployees(id);
        }

        public bool Update(int id, Employee employee)
        {

            if (GetAll().Count() == 0)
                return false;
            if (_employeeRepository.Employees.indexOf(id) == -1)
                return false;
            if (employee.Tz != null && !CheckIDNo(employee.Tz) || employee.PhoneNumber != null && employee.PhoneNumber.Length != 10)
                return false;

            bool flag = _employeeRepository.Employees.Update(id, employee);
            if (flag)
                _employeeRepository.Save();
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