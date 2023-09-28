using GestionEventos.API.Data;
using GestionEventos.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionEventos.API.Controllers
{
    public class EventosController
    {
        [ApiController]
        [Route("/api/Eventos")]
        public class EventosAcademicosController : ControllerBase
        {
            private readonly DataContext _context;

            public EventosAcademicosController(DataContext context)
            {
                _context = context;
            }

            
            [HttpGet]
            public async Task<ActionResult> Get()
            {


                return Ok(await _context.Eventos.ToListAsync());

            }


            [HttpGet("{id:int}")]
            public async Task<ActionResult<EventoAcademico>> GetEventoAcademico(int id)
            {
                var eventoAcademico = await _context.Eventos.FirstOrDefaultAsync(e => e.Id == id);

                if (eventoAcademico == null)
                {
                    return NotFound(); 
                }

                return Ok(eventoAcademico); 
            }

           
            [HttpPost]
            public async Task<ActionResult> Post(EventoAcademico eventoAcademico)
            {
                _context.Add(eventoAcademico);
                await _context.SaveChangesAsync();
                return Ok(eventoAcademico); 
            }

            
            [HttpPut("{id:int}")]
            public async Task<ActionResult<EventoAcademico>> PutEventoAcademico(int id, EventoAcademico eventoAcademico)
            {
                if (id != eventoAcademico.Id)
                {
                    return BadRequest();
                }

                _context.Entry(eventoAcademico).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Eventos.Any(e => e.Id == id))
                    {
                        return NotFound(); 
                    }
                    else
                    {
                        throw;
                    }
                }

                return Ok(eventoAcademico); 
            }

          
            [HttpDelete("{id:int}")]
            public async Task<ActionResult<EventoAcademico>> DeleteEventoAcademico(int id)
            {
                var eventoAcademico = await _context.Eventos.FindAsync(id);

                if (eventoAcademico == null)
                {
                    return NotFound(); 
                }

                _context.Eventos.Remove(eventoAcademico);
                await _context.SaveChangesAsync();

                return NoContent(); 
            }
        }
    }



}

