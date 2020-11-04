﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingLibrary.Contexts;
using BookingLibrary.Models;

namespace BookingLibrary.Controllers.WithoutRepository
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorsController : ControllerBase
    {
        private readonly BookingLibraryContext _context;

        public EditorsController(BookingLibraryContext context)
        {
            _context = context;
        }

        // GET: api/Editors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Editor>>> GetEditors()
        {
            return await _context.Editors.ToListAsync();
        }

        // GET: api/Editors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Editor>> GetEditor(int id)
        {
            var editor = await _context.Editors.FindAsync(id);

            if (editor == null)
            {
                return NotFound();
            }

            return editor;
        }

        // PUT: api/Editors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditor(int id, Editor editor)
        {
            if (id != editor.EditorId)
            {
                return BadRequest();
            }

            _context.Entry(editor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EditorExists(id))
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

        // POST: api/Editors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Editor>> PostEditor([FromBody] Editor editor)
        {
            _context.Editors.Add(editor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEditor", new { 
                id = editor.EditorId,
                name=editor.EditorName
            }, editor);
        }

        // DELETE: api/Editors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Editor>> DeleteEditor(int id)
        {
            var editor = await _context.Editors.FindAsync(id);
            if (editor == null)
            {
                return NotFound();
            }

            _context.Editors.Remove(editor);
            await _context.SaveChangesAsync();

            return editor;
        }

        private bool EditorExists(int id)
        {
            return _context.Editors.Any(e => e.EditorId == id);
        }
    }
}
