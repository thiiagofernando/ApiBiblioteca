using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBiblioteca.Data;
using ApiBiblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EditorasController : ControllerBase
    {
        private readonly BibliotecaContexto _contexto;
        public EditorasController(BibliotecaContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editora>>> Get()
        {
            return await _contexto.Editoras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Editora>> Get(int id)
        {
            var editora = await _contexto.Editoras.FindAsync(id);
            if (editora == null)
                return NotFound();

            return editora;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Editora editora)
        {
            _contexto.Editoras.Add(editora);
            await _contexto.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = editora.Id }, editora);
        }
    }
}