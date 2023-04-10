using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TapInMotion.Data;
using TapInMotion.Models;

namespace TapInMotion.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private void PopulateDropdowns()
        {
            ViewData["SchoolID"] = new SelectList(_context.School, "SchoolID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email");
        }

        private void PopulateDropdowns(Student? student)
        {
            ViewData["SchoolID"] = new SelectList(
                _context.School,
                "SchoolID",
                "Name",
                student?.SchoolID
            );
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email", student?.UserID);
        }

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student.Include(s => s.School).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.School)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            PopulateDropdowns();
            //ViewData["SchoolID"] = new SelectList(_context.School, "SchoolID", "Alias");
            // ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("StudentID,UserID,StudentNumber,SchoolID,Name,StartDate,Major,Minor")]
                Student student
        )
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            /*  ViewData["SchoolID"] = new SelectList(
                 _context.School,
                 "SchoolID",
                 "Alias",
                 student.SchoolID
             );
             ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", student.UserID); */
            PopulateDropdowns(student);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            PopulateDropdowns(student);
            // ViewData["SchoolID"] = new SelectList(
            //     _context.School,
            //     "SchoolID",
            //     "Alias",
            //     student.SchoolID
            // );
            // ViewData["UserID"] = new SelectList(_context.Users, "Id", "Email", student.UserID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("StudentID,UserID,StudentNumber,SchoolID,Name,StartDate,Major,Minor")]
                Student student
        )
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDropdowns(student);
            /*           ViewData["SchoolID"] = new SelectList(
                          _context.School,
                          "SchoolID",
                          "Alias",
                          student.SchoolID
                      );
                      ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", student.UserID); */
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.School)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Student == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Student'  is null.");
            }
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return (_context.Student?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
