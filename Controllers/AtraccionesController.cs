using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EjemploABMCompleto.Data;
using EjemploABMCompleto.Models;

namespace EjemploABMCompleto.Controllers
{
    public class AtraccionesController : Controller
    {
        private readonly AppDbContext _context;

        public AtraccionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Atracciones
        public IActionResult Index()
        {
            var appDbContext = _context.Atracciones.Include(a => a.Parque);
            return View(appDbContext.ToList());
        }

        // GET: Atracciones/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atraccion = _context.Atracciones
                .Include(a => a.Parque)
                .FirstOrDefault(m => m.Id == id);
            if (atraccion == null)
            {
                return NotFound();
            }

            ViewBag.Tipos = Atraccion.Tipos;
            return View(atraccion);
        }

        // GET: Atracciones/Create
        public IActionResult Create()
        {
            ViewData["IdParque"] = new SelectList(_context.Parques, "Id", "Nombre");
            ViewBag.Tipos = Atraccion.Tipos;
            return View();
        }

        // POST: Atracciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre,Descripcion,Tipo,EdadMinima,EdadMaxima,AlturaMinima,AlturaMaxima,FotoUrl,IdParque")] Atraccion atraccion)
        {
            if (ModelState.IsValid)
            {
                if (ExisteAtraccion(atraccion.Nombre) == false)
                {
                    _context.Add(atraccion);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(CreadoConExito));
                } else
                {
                    ViewBag.Error = "La atracción ya existe con ese nombre";
                }
            }
            ViewData["IdParque"] = new SelectList(_context.Parques, "Id", "Nombre", atraccion.IdParque);
            ViewBag.Tipos = Atraccion.Tipos;
            return View(atraccion);
        }

        // GET: Atracciones/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atraccion = _context.Atracciones.Find(id);
            if (atraccion == null)
            {
                return NotFound();
            }

            ViewData["IdParque"] = new SelectList(_context.Parques, "Id", "Nombre", atraccion.IdParque);
            ViewBag.Tipos = Atraccion.Tipos;

            return View(atraccion);
        }

        // POST: Atracciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre,Descripcion,Tipo,EdadMinima,EdadMaxima,AlturaMinima,AlturaMaxima,FotoUrl,IdParque")] Atraccion atraccion)
        {
            if (id != atraccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atraccion);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtraccionExists(atraccion.Id))
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

            ViewBag.Tipos = Atraccion.Tipos;
            ViewData["IdParque"] = new SelectList(_context.Parques, "Id", "EdadObjetivo", atraccion.IdParque);

            return View(atraccion);
        }

        // GET: Atracciones/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atraccion = _context.Atracciones
                .Include(a => a.Parque)
                .FirstOrDefault(m => m.Id == id);

            if (atraccion == null)
            {
                return NotFound();
            }

            return View(atraccion);
        }

        // POST: Atracciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var atraccion = _context.Atracciones.Find(id);
            if (atraccion != null)
            {
                _context.Atracciones.Remove(atraccion);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Atracciones/CreadoConExito
        public IActionResult CreadoConExito()
        {
            return View();
        }

        private bool AtraccionExists(int id)
        {
            return _context.Atracciones.Any(e => e.Id == id);
        }

        private bool ExisteAtraccion(string nombre)
        {
            return _context.Atracciones.Any(e => e.Nombre == nombre);
        }
    }
}
