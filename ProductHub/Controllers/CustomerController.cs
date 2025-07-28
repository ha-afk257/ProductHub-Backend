using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using YourNamespace.Repositories;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository repo = new CustomerRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAll() => Ok(repo.GetAll());

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(long id)
        {
            var customer = repo.GetById(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> Add([FromBody] Customer c)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = repo.Add(c);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Customer c)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!repo.Update(id, c)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (!repo.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}
