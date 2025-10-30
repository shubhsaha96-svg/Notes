using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Models;
using System.Security.Cryptography;

namespace Notes.Controllers
{
    public class NotesController : Controller
    {
        NoteDBContext _context;

        public NotesController(NoteDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            var data = _context.Notes.OrderByDescending(e => e.ModifiedDate).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if(!ModelState.IsValid)
            {
                return View(note);
            }
            _context.Notes.Add(note);
            _context.SaveChanges();
            return RedirectToAction("GetNotes");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var datanote = _context.Notes.Find(Id);
            return View(datanote);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }
            var datanote = _context.Notes.Find(note.Id);
            if (datanote == null)
            {
                return NotFound();
            }
            datanote.NotesTitle = note.NotesTitle;
            datanote.NotesContent = note.NotesContent;
            datanote.ModifiedDate = note.ModifiedDate;
            _context.Notes.Update(datanote);
            _context.SaveChanges();
            return RedirectToAction("GetNotes"); ;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var note = _context.Notes.Find(id);
            return View(note);
        }

        [HttpPost]
        public IActionResult Delete(Note noted)
        {
            var note = _context.Notes.Find(noted.Id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return RedirectToAction("GetNotes");
        }

    }
}
