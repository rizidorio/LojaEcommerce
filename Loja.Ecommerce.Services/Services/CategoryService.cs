using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Ecommerce.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Insert(CategoryModel category)
        {
            if (await _categoryRepository.HasExists(category.Name.ToUpper()))
                throw new Exception("Categoria já cadastrada.");

            var cat = new Category
            {
                Name = category.Name.ToUpper()
            };

            if (string.IsNullOrEmpty(cat.Name))
                throw new Exception("Nome não pode ser em branco.");

            await _categoryRepository.Insert(cat);
        }

        public async Task Update(CategoryModel category)
        {
            var convertedId = ObjectId.Parse(category.Id);

            var queriedCategory = await _categoryRepository.GetById(convertedId);

            if (queriedCategory == null)
                throw new Exception("Categoria não encontrada.");

            var cat = new Category
            {
                Id = convertedId,
                Name = category.Name.ToUpper()
            };

            if (string.IsNullOrEmpty(cat.Name))
                throw new Exception("Nome não pode ser em branco.");

            await _categoryRepository.Update(cat);
        }

        public async Task Delete(ObjectId id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            await _categoryRepository.Delete(id);
        }


        public async Task<IEnumerable<CategoryModel>> GetAll(int skip = 0, int limit = 10)
        {
            var result =  await _categoryRepository.GetAll(skip, limit);

            if (result.Count() == 0)
                throw new Exception("Não existe categoria cadastrada.");

            return result.Select(cat => new CategoryModel { 
                Id = cat.Id.ToString(),
                Name = cat.Name
            });
        }

        public async Task<CategoryModel> GetById(ObjectId id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            var cat = await _categoryRepository.GetById(id);

            if (cat == null)
                throw new Exception("Categoria não encontrada.");

            return new CategoryModel
            {
                Id = cat.Id.ToString(),
                Name = cat.Name
            };
        }

        public async Task<CategoryModel> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("O nome não pode ser em branco.");

            var cat = await _categoryRepository.GetByName(name.ToUpper());

            if (cat == null)
                throw new Exception("Categoria não encontrada.");

            return new CategoryModel
            {
                Id = cat.Id.ToString(),
                Name = cat.Name
            };
        }
    }
}
