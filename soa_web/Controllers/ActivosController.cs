using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ActivoController : Controller
{
    private readonly IActivo _activoService;

    public ActivoController(IActivo activoService)
    {
        _activoService = activoService;
    }

    // GET: Activos
    public async Task<IActionResult> Index()
    {
        var activos = await _activoService.GetAllActivosAsync();
        return View(activos);
    }

    // GET: Activos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || !_activoService.ActivoExists(id.Value))
        {
            return NotFound();
        }

        var activo = await _activoService.GetActivoByIdAsync(id.Value);
        return View(activo);
    }

    // GET: Activos/Create
    public async Task<IActionResult> Create()
    {
        var personas = await _activoService.GetAllPersonasAsync();
        if (personas == null)
        {
            return NotFound();
        }

        ViewData["IdEmpleado"] = new SelectList(personas, "Id", "Id");
        return View();
    }

    // POST: Activos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Date,IdEmpleado")] Activo activo)
    {
        if (ModelState.IsValid)
        {
            await _activoService.AddActivoAsync(activo);
            return RedirectToAction(nameof(Index));
        }

        var personas = await _activoService.GetAllPersonasAsync();
        if (personas == null)
        {
            return NotFound();
        }

        ViewData["IdEmpleado"] = new SelectList(personas, "Id", "Id", activo.IdEmpleado);
        return View(activo);
    }

    // Resto de acciones...

    // No es necesario implementar los métodos de la interfaz IActivo aquí.
}
