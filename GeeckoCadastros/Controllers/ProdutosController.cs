using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeeckoCadastros.Models;
using GeeckoCadastros.BancoDados;
using System.Globalization;


namespace GeeckoCadastros.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly GeeckoCadastrosContext _context;

        public ProdutosController(GeeckoCadastrosContext context)
        {
            _context = context;
        }

public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }
        return View(produto);
    }

    // POST: Produtos/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cod_Prod,CodigoBarras,NomeProd,Categoria,Fabricante,Quantidade,ValorProd")] Produtos produto) // "Produtos" é a classe, e "produto" é o objeto específico dessa classe
    {
        if (id != produto.Cod_Prod)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
        // Supondo que o campo ValorProd agora seja do tipo string (na Model, temporariamente, para permitir a máscara)
            if (!string.IsNullOrEmpty(produto.ValorProd?.ToString()))
            {
                // Certifica que produto.ValorProd seja tratado como string antes de aplicar ".Replace()"
            string valorSemFormatacao = produto.ValorProd?.ToString() ?? "";
            valorSemFormatacao = valorSemFormatacao.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim();


            if (produto.ValorProd != null && double.TryParse(produto.ValorProd.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
            {
                produto.ValorProd = valor;
            }
            else
            {
                ModelState.AddModelError("ValorProd", "Por favor, insira um número válido.");
                return View(produto);
            }

            }

            _context.Update(produto);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProdutoExists(produto.Cod_Prod))
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
    return View(produto);
}

    private bool ProdutoExists(int id)
    {
        return _context.Produtos.Any(e => e.Cod_Prod == id);
    }
        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cod_Prod,CodigoBarras,NomeProd,Categoria,Fabricante,Quantidade,ValorProd")] Produtos produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Cod_Prod == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Cod_Prod == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

