using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.Servico;
using EntityFrameworkPaginateCore;

namespace webapi.Controllers
{
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly DbContexto _context;

        public AlunosController(DbContexto context)
        {
            _context = context;
        }

        // GET: /alunos
        [HttpGet]
        [Route("/alunos")]
        public async Task<IActionResult> Index()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return StatusCode(200, alunos );
        }

        // GET: /alunos/{id}
        [HttpGet]
        [Route("/alunos/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return StatusCode(200, aluno);
        }

        
        // POST: /alunos
        [HttpPost]
        [Route("/alunos")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Notas")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return StatusCode(201, aluno);
            }
            return StatusCode(201, aluno);
        }

        
        // PUT: /alunos/{id}
        [HttpPut]
        [Route("/alunos/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Notas")] Aluno aluno)
        {

            if (ModelState.IsValid)
            {
                try
                {   aluno.Id = id;
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, aluno);
            }
            return StatusCode(200, aluno);
        }


        // DELETE: /alunos/{id}
        [HttpDelete]
        [Route("/alunos/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

            private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
