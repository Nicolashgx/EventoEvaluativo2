using GestionEventos.API.Data;
using GestionEventos.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.API.Controllers
{

    [ApiController]
    [Route("/api/Participante")]
    
        
        public class ParticipantesController : ControllerBase
        {
            private readonly DataContext _context;

            public ParticipantesController(DataContext context)
            {
                _context = context;
            }

         
            [HttpGet]
            public async Task<ActionResult> Get()
            {
                return Ok (await _context.Participante.ToListAsync());
            }

            
            [HttpGet("{id:int}")]
            public async Task<ActionResult<Participantes>> GetParticipante(int id)
            {
                var participante = await _context.Participante.FirstOrDefaultAsync(p => p.Id == id);

                if (participante == null)
                {
                    return NotFound(); 
                }

                return Ok(participante); 
            }

            
            [HttpPost]
            public async Task<ActionResult> Post(Participantes participante)
            {
                _context.Add(participante);
                await _context.SaveChangesAsync();
                return Ok(participante);
            }

            
            [HttpPut("{id:int}")]
            public async Task<ActionResult> Put(int id, Participantes participante)
            {
                if (id != participante.Id)
                {
                    return BadRequest(); 
                }

                _context.Entry(participante).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Participante.Any(p => p.Id == id))
                    {
                        return NotFound(); 
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(participante); 
            }

          
            [HttpDelete("{id:int}")]
            public async Task<ActionResult> DeleteParticipante(int id)
            {
                var participante = await _context.Participante.FindAsync(id);

                if (participante == null)
                {
                    return NotFound(); 
                }

                _context.Participante.Remove(participante);
                await _context.SaveChangesAsync();

                return NoContent(); 
            }
        }
    }



