using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransporteBoletos.Data;
using TransporteBoletos.Models;

namespace TransporteBoletos.Controllers
{
    public class PasajerosController : Controller
    {
        private readonly TransporteBoletosDbContext _context;

        public PasajerosController(TransporteBoletosDbContext context)
        {
            _context = context;
        }

        // GET: Pasajeros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pasajeros.Include(p => p.Ruta).ToListAsync());
        }

        // GET: Pasajeros/Create
        public IActionResult Create()
        {
            // Cargar las rutas en el dropdown
            ViewBag.Rutas = new SelectList(_context.Rutas, "Id", "Origen");
            return View();
        }

        // POST: Pasajeros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Documento,RutaId")] Pasajero pasajero)
        {
            if (ModelState.IsValid)
            {
                // Validación personalizada de cédula en back-end
                if (!IsValidCedula(pasajero.Documento))
                {
                    ModelState.AddModelError("Documento", "La cédula no es válida. Debe contener solo números y tener entre 7 y 10 dígitos.");
                    ViewBag.Rutas = new SelectList(_context.Rutas, "Id", "Origen");
                    return View(pasajero);
                }

                // Guardar el pasajero en la base de datos
                _context.Add(pasajero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores de validación, recargar el dropdown y devolver la vista
            ViewBag.Rutas = new SelectList(_context.Rutas, "Id", "Origen");
            return View(pasajero);
        }

        // Método auxiliar para validar la cédula
        private bool IsValidCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula)) return false;
            return cedula.Length >= 7 && cedula.Length <= 10 && cedula.All(char.IsDigit);
        }

    }
}