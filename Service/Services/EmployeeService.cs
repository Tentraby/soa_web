using Domain;
using Microsoft.Extensions.Logging;
using Repository.DAO;
using Repository.DBContext;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Service
{
    public class EmployeeService : IEmployee
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly EmployeeRepository employeeRepository;

        public EmployeeService(ILogger<EmployeeService> logger, ApplicationDBContext context)
        {
            employeeRepository = new EmployeeRepository(context);
        }
        public int CreateEmploye(Empleado empleado)
        {
            int success = 0;
            try
            {
                success = employeeRepository.Create(empleado);
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);
            }
            return success;
        }

        public List<Empleado> GetEmployees()
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                empleados = employeeRepository.GetEmployees();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return empleados;
        }

    }
}
