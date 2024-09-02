using Microsoft.AspNetCore.Mvc;
using Pecas.Models;

namespace Pecas.Controllers
{
    public class FornecedorController : Controller
    {
        private static IList<Fornecedor> Fornecedores = new List<Fornecedor>()
        {
            new Fornecedor()
            {
                FornecedorId = 1,
                Nome = "Lucas",
                CNPJ = "123456789",
                Pais = "China",
            },

            new Fornecedor()
            {
                FornecedorId = 2,
                Nome = "Caio",
                CNPJ = "123456788",
                Pais = "Brasil"
            }
        };
        public IActionResult Index()
        {
            return View(Fornecedores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Fornecedor fornecedor)
        {
            fornecedor.FornecedorId = Fornecedores.Select(x => x.FornecedorId).Max() + 1;
            Fornecedores.Add(fornecedor);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(Fornecedores.Where(fornecedor => fornecedor.FornecedorId == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fornecedor fornecedor)
        {
            var fornecedorOld = Fornecedores.Where(fornecedor => fornecedor.FornecedorId == fornecedor.FornecedorId).First();
            Fornecedores.Remove(fornecedorOld);
            Fornecedores.Add(fornecedor);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(Fornecedores.Where(fornecedor => fornecedor.FornecedorId == id).First());
        }
        public IActionResult Delete(int id)
        {
            return View(Fornecedores.Where(fornecedor => fornecedor.FornecedorId == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var fornecedor = Fornecedores.FirstOrDefault(fornecedor => fornecedor.FornecedorId == id);

            if (fornecedor != null)
            {
                Fornecedores.Remove(fornecedor);
            }

            return RedirectToAction("Index");
        }

    }
}
