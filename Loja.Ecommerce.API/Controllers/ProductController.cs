using Loja.Ecommerce.Services.Interfaces;
using Loja.Ecommerce.Services.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Linq;

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
        public IActionResult GetAll(int skip = 0, int limit = 20)
        {
            try
            {
                var products = _service.GetAll(skip, limit);

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
        public IActionResult GetById(string id)
        {
            try
            {
                var product = _service.GetById(ObjectId.Parse(id));

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
        public IActionResult Post([FromBody]ProductModel product)
        {
            try
            {
                _service.Insert(product);
                return Created("api/produtos/getproductbyid", product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProductModel product)
        {
            try
            {
                _service.Update(product);
                return Ok("Atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
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
