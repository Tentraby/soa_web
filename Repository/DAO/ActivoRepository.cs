using Domain;
using Repository.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.DAO
{
    public class ActivoRepository
    {
        private readonly ApplicationDBContext _context;

        public ActivoRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool ActivoExists(int id)
        {
            return _context.activos.Any(a => a.Id == id);
        }

        public async Task<List<Activo>> GetActivos()
        {
            return await _context.activos.ToListAsync();
        }


        public int Create(Activo activo)
        {
            _context.activos.Add(activo);
            return _context.SaveChanges();
        }

        public async Task<Activo> GetActivoByIdAsync(int id)
        {
            return await _context.activos.FindAsync(id);
        }

        public async Task<List<Persona>> GetAllPersonasAsync()
        {
            return await _context.personas.ToListAsync();
        }

        public void Update(Activo activo)
        {
            _context.activos.Update(activo);
            _context.SaveChanges();
        }

        public void Delete(Activo activo)
        {
            _context.activos.Remove(activo);
            _context.SaveChanges();
        }

        // Implementa otros métodos de la interfaz IActivo según sea necesario...
    }
}
