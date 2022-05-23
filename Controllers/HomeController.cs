using AppWebMvcCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppWebMvcCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppWebDBContext _context;

        public HomeController(AppWebDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var lstClientes = await _context.Clients.ToListAsync();
            return View(lstClientes);
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Registrar(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se registró el cliente correctamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clients.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Client client)
        {
            if(ModelState.IsValid)
            {
                _context.Update(client);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Se editó el cliente correctamente.";
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clients.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarCliente(int? IdClient)
        {
            var cliente = await _context.Clients.FindAsync(IdClient);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(cliente);
            await _context.SaveChangesAsync();
            TempData["mensaje"] = "Se eliminó el cliente correctamente.";
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}