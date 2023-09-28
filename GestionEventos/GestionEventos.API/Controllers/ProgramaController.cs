using GestionEventos.API.Data;
using GestionEventos.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.API.Controllers
{
    public class ProgramaController
    {
        [ApiController]
        [Route("/api/Programa")]
        public class ProgramaEventosController : ControllerBase
        {
            private readonly DataContext _context;

            public ProgramaEventosController(DataContext context)
            {
                _context = context;
            }

            
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ProgramaEvento>>> GetProgramaEventos()
            {
                return await _context.Programa.ToListAsync();
            }

            
            [HttpGet("{id:int}")]
            public async Task<ActionResult> GetProgramaEvento(int id)
            {
                var programaEvento = await _context.Programa.FirstOrDefaultAsync(p => p.Id == id);

                if (programaEvento == null)
                {
                    return NotFound(); 
                }

                return Ok(programaEvento); 
            }

            
            [HttpPost]
            public async Task<ActionResult> PostProgramaEvento(ProgramaEvento programaEvento)
            {
                _context.Add(programaEvento);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetProgramaEvento), new { id = programaEvento.Id }, programaEvento);
            }

           
            [HttpPut("{id:int}")]
            public async Task<ActionResult> PutProgramaEvento(int id, ProgramaEvento programaEvento)
            {
                if (id != programaEvento.Id)
                {
                    return BadRequest(); 
                }

                _context.Entry(programaEvento).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Programa.Any(p => p.Id == id))
                    {
                        return NotFound(); 
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(programaEvento); 
            }

            
            [HttpDelete("{id:int}")]
            public async Task<ActionResult<ProgramaEvento>> DeleteProgramaEvento(int id)
            {
                var programaEvento = await _context.Programa.FindAsync(id);

                if (programaEvento == null)
                {
                    return NotFound(); 
                }

                _context.Programa.Remove(programaEvento);
                await _context.SaveChangesAsync();

                return NoContent(); 
            }
        }
    }

}

