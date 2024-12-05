using busCompany.Core.Entity;
using busCompany.Core.IRepository;
using busCompany.CORE.IService;

namespace busCompany.SERVICE.Service
{
    public class EmployeesService : IEmployeesService
    {
        readonly IEmployeeRepository _employeeRepository;
        public EmployeesService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public bool Add(Employee employee)
        {
            if (GetEmployee(employee.Id) != null)
                return false;
            if (employee.PhoneNumber.Length != 10 || CheckIDNo(employee.Tz) == false)
                return false;
            return _employeeRepository.Add(employee);
        }

        public bool DeleteOne(int id)
        {
            return _employeeRepository.DeleteEmployees(id);
        }

        public List<Employee> GetAll()
        {
          return  _employeeRepository.GetEmployees();
        }

        public Employee GetEmployee(int id)
        {
            return _employeeRepository.getByIdEmployees(id);
        }

        public bool Update(int id, Employee employee)
        {
           
            if (GetAll().Count == 0)
                return false;
            if (_employeeRepository.indexOf(id) == -1)
                return false;
            if (employee.Tz != null && !CheckIDNo(employee.Tz)||employee.PhoneNumber!=null&&employee.PhoneNumber.Length!=10)
                return false;

            return _employeeRepository.Update(id, employee);
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