using System.ComponentModel.DataAnnotations;

namespace GestionEventos.Shared.Entities
{
    public class EventoAcademico
    {

        public int Id { get; set; }

        [Display(Name = "Evento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Name { get; set; }


        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Finalización")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Ubicación")]
        [MaxLength(150, ErrorMessage = "El campo {0} debe contener únicamente 150 caracteres")]
        public string? Ubiacion { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Display(Name = "Tema")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener únicamente 50 caracteres")]
        public string? Tematica { get; set; }




    }
}
