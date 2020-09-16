using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Ecommerce.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryModel> GetAll(int skip = 0, int limit = 10)
        {
            return _categoryRepository.GetAll(skip, limit).Select(cat => new CategoryModel
            {
                Id = cat.Id.ToString(),
                Name = cat.Name
            });
        }

        public CategoryModel GetById(ObjectId id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            var cat = _categoryRepository.GetById(id);

            return new CategoryModel
            {
                Id = cat.Id.ToString(),
                Name = cat.Name
            };
        }

        public void Insert(CategoryModel category)
        {
            if (_categoryRepository.HasExists(category.Name))
                throw new Exception("Categoria já existe.");

            var cat = new Category
            {
                Name = category.Name
            };

            _categoryRepository.Save(cat);
        }

        public void Update(CategoryModel category)
        {
            var convertedId = ObjectId.Parse(category.Id);

            var queriedCategory = _categoryRepository.GetById(convertedId);

            if (queriedCategory == null)
                throw new Exception("Categoria não encontrada.");
            
            var cat = new Category
            {
                Id = convertedId,
                Name = category.Name
            };

            _categoryRepository.Update(cat);
        }

        public void Delete(ObjectId id)
        {
            if(id == null)
                throw new Exception("Id não pode ser em branco.");

            _categoryRepository.Delete(id);
        }
    }
}
