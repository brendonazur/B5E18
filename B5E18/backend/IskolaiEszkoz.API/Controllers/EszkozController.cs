using IskolaiEszkoz.API.Model;
using IskolaiEszkoz.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace IskolaiEszkoz.API.Controllers
{
    [Route("api/eszkozok")]
    [ApiController]
    public class EszkozController : ControllerBase
    {
        private readonly IEszkozService _eszkozService;

        public EszkozController(IEszkozService eszkozService)
        {
            _eszkozService = eszkozService;
        }

        // GET http://localhost:5242/api/eszkozok
        [HttpGet]
        public ActionResult<List<Eszkoz>> OsszesLekerese()
        {
            List<Eszkoz> eszkozok = _eszkozService.OsszesLekerese();
            return Ok(eszkozok);
        }

        // POST http://localhost:5242/api/eszkozok
        [HttpPost]
        public ActionResult<int> Letrehozas(Eszkoz eszkoz)
        {
            int ujId = _eszkozService.Letrehozas(eszkoz);
            return StatusCode(201, ujId);
        }

        // PUT http://localhost:5242/api/eszkozok/1
        [HttpPut("{id}")]
        public IActionResult Modositas(int id, Eszkoz eszkoz)
        {
            bool sikeres = _eszkozService.Modositas(id, eszkoz);

            if (!sikeres)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE http://localhost:5242/api/eszkozok/1
        [HttpDelete("{id}")]
        public IActionResult Torles(int id)
        {
            bool sikeres = _eszkozService.Torles(id);

            if (!sikeres)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
