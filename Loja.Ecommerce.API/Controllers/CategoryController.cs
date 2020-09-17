﻿using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll(int skip = 0, int limit = 10)
        {
            try
            {
                var categories = await _service.GetAll(skip, limit);

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
        public async Task<IActionResult> GetCategoryById(string id)
        {
            try
            {
                var category = await _service.GetById(ObjectId.Parse(id));

                if (category == null)
                    return NotFound();

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [Route("buscarPorNome/{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            try
            {
                var category = await _service.GetByName(name);

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
        public async Task<IActionResult> Post([FromBody] CategoryModel category)
        {
            try
            {
                await _service.Insert(category);
                return Created("api/categorias/GetCategoryById", category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryModel category)
        {
            try
            {
                await _service.Update(category);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _service.Delete(ObjectId.Parse(id));

                return Ok("Apagado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}