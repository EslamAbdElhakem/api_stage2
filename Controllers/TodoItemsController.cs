using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_stage2.Models;

namespace api_stage2.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly stageContext _context;

        public TodoItemsController(stageContext context)
        {
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<stageItem>>> GetTodoItems()
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<stageItem>> GetstageItem(long id)
        {
          if (_context.TodoItems == null)
          {
              return NotFound();
          }
            var stageItem = await _context.TodoItems.FindAsync(id);

            if (stageItem == null)
            {
                return NotFound();
            }

            return stageItem;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutstageItem(long id, stageItem stageItem)
        {
            if (id != stageItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stageItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!stageItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult CreatePerson(PersonDto personDto)
        {
            // Extract the relevant information
            string name = personDto.Name;
            int age = personDto.Age;

            // Perform some validation on the data (optional)
            if (string.IsNullOrEmpty(name) || age <= 0)
            {
                return BadRequest("Name and age are required fields.");
            }

            // Create a new person object
            stageItem person = new stageItem
            {
                Name = name,
                Age = age
            };

            // Add the person to the in-memory database
            _context.TodoItems.Add(person);
            _context.SaveChanges();

            // Return a success response
            return Ok("Person created successfully.");
        }
    

   

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool stageItemExists(long id)
        {
            return (_context.TodoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
