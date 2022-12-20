using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Servico;

namespace webapi.Controllers
{
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly DbContexto _context;

        public FornecedoresController(DbContexto context)
        {
            _context = context;
        }

        // GET: /fornecedores
        [HttpGet]
        [Route("/fornecedores")]
        public async Task<IActionResult> Index()
        {
            var fornecedores = await _context.Fornecedores.ToListAsync();
            return StatusCode(200, fornecedores );
        }

        // GET: /fornecedores/{codigo}
        [HttpGet]
        [Route("/fornecedores/{codigo}")]
        public async Task<IActionResult> Details(int? codigo)
        {
            if (codigo == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Codigo == codigo);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return StatusCode(200, fornecedor);
        }

        
        // POST: /fornecedores
        [HttpPost]
        [Route("/fornecedores")]
        public async Task<IActionResult> Create( Fornecedores fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return StatusCode(201, fornecedor);
            }
            return StatusCode(201, fornecedor);
        }

        
        // PUT: /fornecedores/{codigo}
        [HttpPut]
        [Route("/fornecedores/{codigo}")]
        public async Task<IActionResult> Edit(int codigo, Fornecedores fornecedor)
        {

            if (ModelState.IsValid)
            {
                try
                {   fornecedor.Codigo = codigo;
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(fornecedor.Codigo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, fornecedor);
            }
            return StatusCode(200, fornecedor);
        }


        // DELETE: /fornecedores/{codigo}
        [HttpDelete]
        [Route("/fornecedores/{codigo}")]
        public async Task<IActionResult> DeleteConfirmed(int codigo)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(codigo);
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

            private bool AlunoExists(int codigo)
        {
            return _context.Fornecedores.Any(e => e.Codigo == codigo);
        }
    }
}
