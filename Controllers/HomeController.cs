using EjemploABMCompleto.Data;
using EjemploABMCompleto.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjemploABMCompleto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.TotalParques = _context.Parques.Count();
            return View();
        }
        public IActionResult PrecargaDatos()
        {
            _context.Parques.Add(new Parque() { Nombre = "Parque de la Costa", EdadObjetivo = "Niños" });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            _context.Parques.Add(new Parque() { Nombre = "Parque de la Costa", EdadObjetivo = "Niños" });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
