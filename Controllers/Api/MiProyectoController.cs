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

        [HttpGet("presentacion")]
        public IActionResult Presentacion() {
            var client = new MongoClient(CadenaConexion.MONGO_DB);
            var bd = client.GetDatabase("Escuela_Zaira_Atala");
            var collection = bd.GetCollection<Equipo>("Equipo");
            var list = collection.Find(FilterDefinition<Equipo>.Empty).ToList();

           return Ok (list);
        }
    }
    