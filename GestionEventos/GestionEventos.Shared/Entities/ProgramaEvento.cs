using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Shared.Entities
{
    public class ProgramaEvento
    {
        public int Id { get; set; }

        [Display(Name = "Evento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int EventoAcademicoId { get; set; } 

        [Display(Name = "Hora de Inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime HoraInicio { get; set; }

        [Display(Name = "Hora de Finalización")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime HoraFin { get; set; }

        [Display(Name = "Sesión")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener únicamente 50 caracteres")]
        public string? Sesion { get; set; }

        [Display(Name = "Ponente")]
        public int? Participante { get; set; } 

        [Display(Name = "Tema")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 caracteres")]
        public string? Tema { get; set; }




    }
}
