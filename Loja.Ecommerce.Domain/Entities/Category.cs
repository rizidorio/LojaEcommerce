using System;

namespace Loja.Ecommerce.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            Validate(name);

            Id = CreateId();
            Name = name;
        }

        public Category(Guid id, string name)
        {
            Validate(name);
            Id = id;
            Name = name;
        }

        private static void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new Exception("O Nome não pode ser em branco.");

            if (name.Length < 3 || name.Length > 50) 
                throw new Exception("O Nome deve ter entre 3 e 50 caracteres");
        }

        private static Guid CreateId()
        {
            return Guid.NewGuid();
        }
    }
}
