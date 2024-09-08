using DapperWithPostgreSql.Models;
using DapperWithPostgreSql.Repositories;

namespace DapperWithPostgreSql.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ISarkarRepository _dbService;

        public EmployeeService(ISarkarRepository dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            var result =
                await _dbService.EditData(
                    "INSERT INTO public.employees (id,name, age, address, mobile_no) VALUES (@Id, @Name, @Age, @Address, @MobileNo)",
                    employee);
            return true;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            var employeeList = await _dbService.GetAll<Employee>("SELECT * FROM public.employees", new { });
            return employeeList;
        }


        public async Task<Employee> GetEmployee(int id)
        {
            var employeeList = await _dbService.GetAsync<Employee>("SELECT * FROM public.employees where id=@id", new { id });
            return employeeList;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var updateEmployee =
                await _dbService.EditData(
                    "Update public.employees SET name=@Name, age=@Age, address=@Address, mobile_no=@MobileNo WHERE id=@Id",
                    employee);
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var deleteEmployee = await _dbService.EditData("DELETE FROM public.employees WHERE id=@Id", new { id });
            return true;
        }
    }
}
