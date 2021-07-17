using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using ApiPrestamos.Models;
using ApiPrestamos.Services;

namespace ApiPrestamos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {

        public PersonasController()
        {
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Personas>> GetAll() => PersonasService.GetList();

        [HttpGet("{PersonaId}")]
        public ActionResult<Personas> Get(int PersonaId)
        {
            var persona = PersonasService.Buscar(PersonaId);
            if (persona == null)
                return NotFound();

            return persona;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Personas persona)
        {
            PersonasService.Guardar(persona);
            return CreatedAtAction(nameof(Create), new { id = persona.PersonaId }, persona);
            // This code will save the persona and return a result
        }

        [HttpPatch]
        public IActionResult Modify(string id, [FromBody] JsonPatchDocument<Personas> patchDoc)
        {
            if (int.TryParse(id, out _))
            {
                var persona = PersonasService.Buscar(int.Parse(id));

                if (persona.PersonaId == 0)
                    return NotFound();

                patchDoc.ApplyTo(persona);
                PersonasService.Guardar(persona);

                return NoContent();
            }
            else
                return BadRequest();

        }

        [HttpDelete("{PersonaId}")]
        public IActionResult Delete(int PersonaId)
        {
            var persona = Get(PersonaId);
            if (persona is null)
                return NotFound();
            PersonasService.Eliminar(PersonaId);
            return NoContent();
        }

        [HttpPut("{PersonaId}")]
        public IActionResult Update(int PersonaId, Personas persona)
        {
            if (PersonaId != persona.PersonaId)
                return BadRequest();
            var existingPizza = Get(PersonaId);
            if (existingPizza is null)
                return NotFound();
            PersonasService.Guardar(persona);

            return NoContent();
        }
    }
}
