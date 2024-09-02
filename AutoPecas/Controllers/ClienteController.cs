using Microsoft.AspNetCore.Mvc;
using Pecas.Models;

namespace Pecas.Controllers
{
    public class ClienteController : Controller
    {
        private static IList<Cliente> Clientes = new List<Cliente>()
        {
            new Cliente()
            {
                ClienteId = 1,
                Nome = "Arthur",
                CPF= 0000001,
                Telefone = 24999873579,
                Email = "arthur@gmail.com"

            },
            new Cliente()
            {
                ClienteId= 2,
                Nome = "Ana",
                CPF= 00000091,
                Telefone = 24999888239,
                Email = "ana@gmail.com"

            }
        };
        public IActionResult Index()
        {
            return View(Clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Cliente cliente)
        {
           cliente.ClienteId = Clientes.Select(x => x.ClienteId).Max() + 1; 
           Clientes.Add(cliente);
           return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
          return View(Clientes.Where(cliente => cliente.ClienteId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            var clienteOld = Clientes.Where(cliente => cliente.ClienteId == cliente.ClienteId).First();
            Clientes.Remove(clienteOld);
            Clientes.Add(cliente); 
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(Clientes.Where(cliente => cliente.ClienteId == id).First());
        }
        public IActionResult Delete(int id)
        {
            return View(Clientes.Where(cliente => cliente.ClienteId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
           var cliente = Clientes.Where(cliente => cliente.ClienteId == id).First();
            Clientes.Remove(cliente);
            return RedirectToAction("Index");
        }
    }
}
