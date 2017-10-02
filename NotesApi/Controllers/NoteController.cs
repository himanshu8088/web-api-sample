using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Model;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private NoteContext _context;

        public NoteController(NoteContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            var note = (from n in _context.Notes
                       where n.Id == id
                       select n).FirstOrDefault();            
            return note;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Note note)
        {
            if (ModelState.IsValid == false)
                return BadRequest();
            _context.Notes.Add(note);
            _context.SaveChanges();
            return CreatedAtAction("get",note);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var note = (from n in _context.Notes
                        where n.Id == id
                        select n).FirstOrDefault();
            if (note == null)
                return NotFound();
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
