using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IRepository _repository {get;}
        public ProductsController (IRepository repository){
            _repository = repository;
        }

        [HttpGet("list")]
        public async Task<IActionResult> Get(){
            try {
                var result = await _repository.GetAllProductsAsync();
                return Ok(result);
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error code 500: Internal Server Error");
            }
        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProductById(int ProductId){
            try {
                var result = await _repository.GetProductAsyncById(ProductId);
                return Ok(result);
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error code 500: Internal Server Error");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(Product model){
            try {
                _repository.Add(model);
                if(await _repository.SaveChangesAsync()){
                    return Created("$/api/products/register/{mmodel.Id}", model);
                }
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error code 500: Internal Server Error");
            }
            return BadRequest();
        }

        [HttpPut("edit/{ProductId}")]
        public async Task<IActionResult> Put(int ProductId, Product model){
            try {
                var product = await _repository.GetProductAsyncById(ProductId);
                if(product == null)
                return NotFound();

                _repository.Update(model);

                if(await _repository.SaveChangesAsync()){
                    product = await _repository.GetProductAsyncById(ProductId);
                    return Created("$/api/products/edit/{model.Id}", product);
                }
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error code 500: Internal Server Error");
            }
            return BadRequest();
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> Delete(int ProductId){
            try{
                var product = await _repository.GetProductAsyncById(ProductId);
                if(product == null)
                return NotFound();

                _repository.Delete(product);

                if(await _repository.SaveChangesAsync()){
                    return Ok();
                }
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Error code 500: Internal Server Error");
            }
            return BadRequest();
        }
    }
}
