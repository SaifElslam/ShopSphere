using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSphere.Models;
using ShopSphere.Repositories;
using ShopSphere.Services;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace ShopSphere.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IMapper _mapper;
        public ProductsController (IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }
        [HttpPost]
        public async Task<IActionResult> Create (Product product)
        {
            var created = await _service.CreateAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);

        }
        [HttpPut ("{id}")]
        public async Task <IActionResult> Update(int id,Product product)
        {
            var result = await _service.UpdateAsync(id, product);
            if (!result)
            {
                return NotFound();
            }
            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
