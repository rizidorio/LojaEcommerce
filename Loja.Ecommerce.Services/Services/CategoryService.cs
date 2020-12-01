using Loja.Ecommerce.Domain.Entities;
using Loja.Ecommerce.Domain.Interfaces;
using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
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

        public async Task<CategoryModel> Insert(CategoryModel category)
        {
            if (await _categoryRepository.HasExists(category.Name.ToUpper()))
                throw new Exception("Categoria já cadastrada.");

            var convertedCategory = new Category(null, category.Name.ToUpper());

            var result = await _categoryRepository.Insert(convertedCategory);

            if (result != null)
                category.Id = result.Id.ToString();
            

            return category;
        }

        public async Task Update(CategoryModel category)
        {
            var queriedCategory = await _categoryRepository.GetById(category.Id);

            if (queriedCategory == null)
                throw new Exception("Categoria não encontrada.");

            var convertedCategory = new Category(Guid.Parse(category.Id), category.Name.ToUpper());

            await _categoryRepository.Update(convertedCategory);
        }

        public async Task Delete(string id)
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

            return result.Select(category => new CategoryModel { 
                Id = category.Id.ToString(),
                Name = category.Name
            });
        }

        public async Task<CategoryModel> GetById(string id)
        {
            if (id == null)
                throw new Exception("O Id não pode ser em branco.");

            var category = await _categoryRepository.GetById(id);

            if (category == null)
                throw new Exception("Categoria não encontrada.");

            return new CategoryModel
            {
                Id = category.Id.ToString(),
                Name = category.Name
            };
        }

        public async Task<CategoryModel> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("O nome não pode ser em branco.");

            var category = await _categoryRepository.GetByName(name.ToUpper());

            if (category == null)
                throw new Exception("Categoria não encontrada.");

            return new CategoryModel
            {
                Id = category.Id.ToString(),
                Name = category.Name
            };
        }
    }
}
