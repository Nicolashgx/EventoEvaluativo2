using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Shared.Entities
{
    public class Participantes
    {
        
    public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener únicamente 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? Nombre { get; set; }

        [Display(Name = "Afiliación Institucional")]
        [MaxLength(150, ErrorMessage = "El campo {0} debe contener únicamente 150 caracteres")]
        public string? Afiliacion { get; set; }

        [Display(Name = "Área de Interés")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener únicamente 50 caracteres")]
        public string? AreaInteres { get; set; }

        [Display(Name = "Tipo de Participación")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe contener únicamente 20 caracteres")]
        public string? TipoParticipacion { get; set; } 
    









}
}
