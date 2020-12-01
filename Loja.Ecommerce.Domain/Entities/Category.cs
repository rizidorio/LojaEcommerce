using System;

namespace Loja.Ecommerce.Domain.Entities
{
    public class Category
    {
        public Guid? Id { get; private set; }
        public string Name { get; private set; }

        public Category(Guid? id, string name)
        {
            Validate(name);

            if (id == null)
                Id = Guid.NewGuid();
            else
                Id = id;

            Name = name;
        }

        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new Exception("O Nome não pode ser em branco.");

            if (name.Length < 3 || name.Length > 50) 
                throw new Exception("O Nome deve ter entre 3 e 50 caracteres");
        }
    }
}
