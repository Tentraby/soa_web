using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace soa_web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employe)
        {
            _employeeService = employe;
        }

        public IActionResult Index()
        {
             var lista = _employeeService.GetEmployees();
            return View(lista);
        }

        public IActionResult Create() 
        { 
            return View();
        }

        public IActionResult Create(Empleado empleado) 
        {
            var result = _employeeService.CreateEmploye( empleado);

            if (result > 0)
            {
                return RedirectToAction("Index");    
                
            }
            else
            {
                return View(result);
            }
        }
    }
}
