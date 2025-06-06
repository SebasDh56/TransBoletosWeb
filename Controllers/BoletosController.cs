﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransporteBoletos.Data;
using TransporteBoletos.Models;

namespace TransporteBoletos.Controllers
{
    public class BoletosController : Controller
    {
        private readonly TransporteBoletosDbContext _context;

        public BoletosController(TransporteBoletosDbContext context)
        {
            _context = context;
        }

        // GET: Boletos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boletos
                .Include(b => b.Ruta)
                .Include(b => b.Pasajero)
                .ToListAsync());
        }

        // GET: Boletos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .Include(b => b.Pasajero)
                .Include(b => b.Ruta)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // GET: Boletos/Create
        public IActionResult Create()
        {
            ViewBag.Rutas = new SelectList(_context.Rutas, "Id", "Origen");
            ViewBag.Pasajeros = new SelectList(_context.Pasajeros, "Id", "Nombre");
            return View();
        }

        // POST: Boletos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroBoleto,FechaCompra,RutaId,PasajeroId")] Boleto boleto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boleto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Rutas = new SelectList(_context.Rutas, "Id", "Origen");
            ViewBag.Pasajeros = new SelectList(_context.Pasajeros, "Id", "Nombre");
            return View(boleto);
        }

        // GET: Boletos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }

            ViewBag.Rutas = new SelectList(_context.Rutas, "Id", "Origen", boleto.RutaId);
            ViewBag.Pasajeros = new SelectList(_context.Pasajeros, "Id", "Nombre", boleto.PasajeroId);
            return View(boleto);
        }

        // POST: Boletos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroBoleto,RutaId,PasajeroId,FechaCompra")] Boleto boleto)
        {
            if (id != boleto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boleto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoletoExists(boleto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Rutas = new SelectList(_context.Rutas, "Id", "Origen", boleto.RutaId);
            ViewBag.Pasajeros = new SelectList(_context.Pasajeros, "Id", "Nombre", boleto.PasajeroId);
            return View(boleto);
        }

        // GET: Boletos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boleto = await _context.Boletos
                .Include(b => b.Pasajero)
                .Include(b => b.Ruta)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (boleto == null)
            {
                return NotFound();
            }

            return View(boleto);
        }

        // POST: Boletos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto != null)
            {
                _context.Boletos.Remove(boleto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoletoExists(int id)
        {
            return _context.Boletos.Any(e => e.Id == id);
        }
    }
}