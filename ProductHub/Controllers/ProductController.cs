using Microsoft.AspNetCore.Mvc;
using ProductHub.Models;
using ProductHub.Repositories;

namespace ProductHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _repository;

        public ProductController()
        {
            _repository = new ProductRepository();
        }

        // GET: api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _repository.GetAll();
            return Ok(products);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(long id)
        {
            var product = _repository.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST api/product
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            var created = _repository.Add(product);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            var updated = _repository.Update(id, product);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var deleted = _repository.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
