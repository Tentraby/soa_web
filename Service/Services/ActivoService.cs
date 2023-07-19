using Microsoft.Extensions.Logging;
using Service.IService;
using Repository.DAO;
using Repository.DBContext;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ActivoService : IActivo
{
    private readonly ILogger<ActivoService> _logger;
    private readonly ActivoRepository _activoRepository;

    public ActivoService(ILogger<ActivoService> logger, ApplicationDBContext context)
    {
        _logger = logger;
        _activoRepository = new ActivoRepository(context);
    }

    public bool ActivoExists(int id)
    {
        return _activoRepository.ActivoExists(id);
    }

    public async Task AddActivoAsync(Activo activo)
    {
        try
        {
            _activoRepository.Create(activo);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<Activo> GetActivoByIdAsync(int id)
    {
        return await _activoRepository.GetActivoByIdAsync(id);
    }

    public async Task<List<Activo>> GetActivos()
    {
        List<Activo> activos = new List<Activo>();

        try
        {
            activos = await _activoRepository.GetActivos();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }

        return activos;
    }


    public async Task<List<Persona>> GetAllPersonasAsync()
    {
        return await _activoRepository.GetAllPersonasAsync();
    }

    public async Task UpdateActivoAsync(Activo activo)
    {
        try
        {
            _activoRepository.Update(activo);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task DeleteActivoAsync(int id)
    {
        try
        {
            var activo = await _activoRepository.GetActivoByIdAsync(id);
            if (activo != null)
            {
                _activoRepository.Delete(activo);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    public Task<List<Activo>> GetAllActivosAsync()
    {
        throw new NotImplementedException();
    }
}
