﻿using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Ecommerce.API.Controllers
{
    [Route("api/produtos")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int skip = 0, int limit = 20)
        {
            try
            {
                var products = await _service.GetAll(skip, limit);

                if (!products.Any())
                    return NotFound();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var product = await _service.GetById(ObjectId.Parse(id));

                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ListarPorCategoria/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            try
            {
                var product = await _service.GetByCategory(category);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("BuscarporSku/{sku}")]
        public async Task<IActionResult> GetBySku(string sku)
        {
            try
            {
                var product = await _service.GetBySku(sku);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductModel product)
        {
            try
            {
                await _service.Insert(product);
                return Created("api/produtos/getproductbyid", product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductModel product)
        {
            try
            {
                await _service.Update(product);
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