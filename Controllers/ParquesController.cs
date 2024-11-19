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
    public class ParquesController : Controller
    {
        private readonly AppDbContext _context;

        public ParquesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Parques/Buscar
        public IActionResult Buscar(string busqueda) {
            if (busqueda != null)
            {
                Console.WriteLine(busqueda);
                ViewBag.Busqueda = busqueda;
                ViewBag.Encontrados = _context.Parques.Where(
                    p => p.Nombre.Contains(busqueda)
                ).ToList();
            } else
            {
                ViewBag.Encontrados = new List<Parque>();
            }
            return View();
        }
        // GET: Parques
        public IActionResult Index()
        {
            return View(_context.Parques.ToList());
        }

        // GET: Parques/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parque = _context.Parques
                .Include(p => p.Atracciones)
                .FirstOrDefault(m => m.Id == id);
            if (parque == null)
            {
                return NotFound();
            }

            return View(parque);
        }

        // GET: Parques/Create
        public IActionResult Create()
        {
            ViewBag.EdadesObjetivo = Parque.EdadesObjetivo;
            return View();
        }

        // POST: Parques/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre,Telefono,Direccion,EdadObjetivo")] Parque parque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parque);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EdadesObjetivo = Parque.EdadesObjetivo;
            return View(parque);
        }

        // GET: Parques/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parque = _context.Parques.Find(id);
            if (parque == null)
            {
                return NotFound();
            }

            ViewBag.EdadesObjetivo = Parque.EdadesObjetivo;
            return View(parque);
        }

        // POST: Parques/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre,Telefono,Direccion,EdadObjetivo")] Parque parque)
        {
            if (id != parque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parque);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParqueExists(parque.Id))
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

            ViewBag.EdadesObjetivo = Parque.EdadesObjetivo;
            return View(parque);
        }

        // GET: Parques/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parque = _context.Parques
                .FirstOrDefault(m => m.Id == id);
            if (parque == null)
            {
                return NotFound();
            }

            return View(parque);
        }

        // POST: Parques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var parque = _context.Parques.Find(id);
            if (parque != null)
            {
                _context.Parques.Remove(parque);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ParqueExists(int id)
        {
            return _context.Parques.Any(e => e.Id == id);
        }
        private bool ParqueExists(string nombre)
        {
            return _context.Parques.Any(e => e.Nombre == nombre);
        }
    }
}
