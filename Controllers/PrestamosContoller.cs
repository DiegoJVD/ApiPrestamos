using ApiPrestamos.Models;
using ApiPrestamos.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrestamos.Controllers
{
    public class PrestamosContoller: ControllerBase
    {
        // GET all action
        [HttpGet]
        public ActionResult<List<Prestamos>> GetAll() => PrestamosService.GetList();

        [HttpGet("{PrestamoId}")]
        public ActionResult<Prestamos> Get(int PrestamoId)
        {
            var prestamo = PrestamosService.Buscar(PrestamoId);
            if (prestamo == null)
                return NotFound();

            return prestamo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Prestamos prestamo)
        {
            PrestamosService.Guardar(prestamo);
            return CreatedAtAction(nameof(Create), new { id = prestamo.PrestamoId }, prestamo);
            // This code will save the prestamo and return a result
        }

        [HttpPatch]
        public IActionResult Modify(string id, [FromBody] JsonPatchDocument<Prestamos> patchDoc)
        {
            if (int.TryParse(id, out _))
            {
                var prestamo = PrestamosService.Buscar(int.Parse(id));

                if (prestamo.PrestamoId == 0)
                    return NotFound();

                patchDoc.ApplyTo(prestamo);
                PrestamosService.Guardar(prestamo);

                return NoContent();
            }
            else
                return BadRequest();

        }

        [HttpDelete("{PrestamoId}")]
        public IActionResult Delete(int PrestamoId)
        {
            var prestamo = Get(PrestamoId);
            if (prestamo is null)
                return NotFound();
            PrestamosService.Eliminar(PrestamoId);
            return NoContent();
        }

        [HttpPut("{PrestamoId}")]
        public IActionResult Update(int PrestamoId, Prestamos prestamo)
        {
            if (PrestamoId != prestamo.PrestamoId)
                return BadRequest();
            var existingPizza = Get(PrestamoId);
            if (existingPizza is null)
                return NotFound();
            PrestamosService.Guardar(prestamo);

            return NoContent();
        }
    }
}
