using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MiProyecto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]

    [BsonElement("nombre_integrante1")]
    public string NombreIntegrante1 { get; set; } = string.Empty;

    [BsonElement("nombre_integrante2")]
    public string NombreIntegrante2 { get; set; } = string.Empty;
}