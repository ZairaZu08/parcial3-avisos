using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

    [Route("api/mi-proyecto")]
    public class MiProyectoController : ControllerBase
    {
        [HttpGet("integrantes")]
        public IActionResult Integrantes()
        {
            var integrantes = new MiProyecto
            {
                NombreIntegrante1 = "Zaira Lizeth Zuñiga Bravo",
                NombreIntegrante2 = "Atala Jareny Bustamante Medellin"
            };

            return Ok(integrantes);
        }
    }
