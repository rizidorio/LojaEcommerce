﻿using System;

namespace Loja.Ecommerce.Domain.Entities
{
    public class Product
    {
        public Guid? Id { get; private set; }
        public string SKU { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public string ImageUrl { get; private set; }
        public Category Category { get; private set; }
        public decimal Price { get; private set; }

        public Product(Guid? id, string sku, string name, string description, string brand, string imageUrl, Category category, decimal price)
        {
            Validate(sku, name, brand, price);

            if (id == null)
                Id = Guid.NewGuid();
            else
                Id = id;

            SKU = sku.ToUpper();
            Name = name;
            Description = description;
            Brand = brand;
            ImageUrl = imageUrl;
            Category = category;
            Price = price;
        }

        private static void Validate(string sku, string name, string brand, decimal price)
        {
            if (string.IsNullOrWhiteSpace(sku)) 
                throw new Exception("O SKU não pode ser em branco.");

            if (string.IsNullOrWhiteSpace(name)) 
                throw new Exception("O Nome não pode ser em branco.");

            if (name.Length < 3 || name.Length > 50) 
                throw new Exception("O Nome deve ter entre 3 e 50 caracteres");

            if (string.IsNullOrWhiteSpace(brand)) 
                throw new Exception("A Marca não pode ser em branco");

            if (price <= 0) 
                throw new Exception("O Preço não pode ser menor ou igual a 0");
        }
    }
}
