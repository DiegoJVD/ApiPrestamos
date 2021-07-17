using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrestamos.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir una persona")]
        public int PersonaId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Concepto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir un monto"), Range(minimum: 1, maximum: 5000000, ErrorMessage = "Debe tener Estar en un rango de 1- 5 Millones")]
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
    }
}
