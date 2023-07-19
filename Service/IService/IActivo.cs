using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IActivo
{
    bool ActivoExists(int id);

    Task AddActivoAsync(Activo activo);

    Task<Activo> GetActivoByIdAsync(int id);

    Task<List<Activo>> GetAllActivosAsync();

    Task<List<Persona>> GetAllPersonasAsync();

    Task UpdateActivoAsync(Activo activo);

    Task DeleteActivoAsync(int id);
}