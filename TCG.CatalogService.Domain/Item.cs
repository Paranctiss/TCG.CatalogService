using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TCG.CatalogService.Domain;

public class Item
{
    [BsonId]
    public ObjectId _id { get; set; }
    //IdExtention : base1
    public string IdExtension { get; set; }
    public string LibelleExtension { get; set; }
    //IdCar : base1-1
    public string Name { get; set; }
    public string Image { get; set; }
    public string Language { get; set; } = "fr";
    public string IdCard { get; set; }
}