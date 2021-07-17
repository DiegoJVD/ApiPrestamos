using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrestamos.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        [Required(ErrorMessage ="Es obligatorio introducir el nombre")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el Apellido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage ="Es Obligatorio introducir la cedula ")]
        public string Cedula { get; set; }

        public decimal Balance { get; set; } = 0;


    }
}
