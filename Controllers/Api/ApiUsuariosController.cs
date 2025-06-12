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
        public IActionResult ListarUsuarios(string? texto)
        {
            var filter = FilterDefinition<Usuario>.Empty;
            if(!string.IsNullOrWhiteSpace(texto))
            {
                var filterNombre = Builders<Usuario>.Filter.Regex(X => X.Nombre, new BsonRegularExpression(texto, "i"));
                var filterCorreo = Builders<Usuario>.Filter.Regex(X => X.Correo, new BsonRegularExpression(texto, "i"));
                filter = Builders<Usuario>.Filter.Or(filterNombre, filterCorreo);
            }

            var list = this.collection.Find(filter).ToList();

            return Ok(list);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var filter = Builders<Usuario>.Filter.Eq(x => x.Id, id);
            var item = this.collection.Find(filter).FirstOrDefault();
            if (item != null)
            {
                this.collection.DeleteOne(filter);
            }

            return NoContent();
        }
    }
    