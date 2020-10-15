using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Loja.Ecommerce.Domain.Entities
{
    public class Category
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }

        public Category(string id, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("O Nome não pode ser em branco.");
            if (name.Length < 3 || name.Length > 50) throw new Exception("O Nome deve ter entre 3 e 50 caracteres");

            Id = id;
            Name = name;
        }
    }
}
