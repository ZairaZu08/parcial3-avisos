using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/usuarios")]
    public class ApiUsuariosController : ControllerBase
    {
        //Metodos para hacer operaciones CRUD
        // C = Create
        // R= Read
        // U= Update
        // D= Delete

        private readonly IMongoCollection<Usuario> collection;
        public ApiUsuariosController()
        {
            var client = new MongoClient(CadenaConexion.MONGO_DB);
            var database = client.GetDatabase("Escuela_Zaira_Atala");
            this.collection = database.GetCollection<Usuario>("Usuarios");
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            var filter = FilterDefinition<Usuario>.Empty;
            var list = this.collection.Find(filter).ToList();
            return Ok(list);
        }
    }
    