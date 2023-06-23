using Domain;
using Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class EmployeeRepository
    {
        private readonly ApplicationDBContext _context;
        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Empleado> GetEmployees()
        {
            return _context.empleados.ToList();
        }

        public int Create(Empleado empleado)
        {
            _context.empleados.Add(empleado);
                return _context.SaveChanges();
        }

    }
}
