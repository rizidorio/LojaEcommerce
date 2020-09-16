using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Linq;

namespace Loja.Ecommerce.API.Controllers
{
    [Route("api/categorias")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll(int skip = 0, int limit = 10)
        {
            try
            {
                var categories = _service.GetAll(skip, limit);

                if (!categories.Any())
                    return NotFound();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(string id)
        {
            try
            {
                var category = _service.GetById(ObjectId.Parse(id));

                if (category == null)
                    return NotFound();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoryModel category)
        {
            try
            {
                _service.Insert(category);
                return Created("api/categorias/getcategorybyid", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] CategoryModel category)
        {
            try
            {
                _service.Update(category);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                _service.Delete(ObjectId.Parse(id));

                return Ok("Apagado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
