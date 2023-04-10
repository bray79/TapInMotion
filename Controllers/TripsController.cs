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
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trip_1.Include(t => t.EndStation).Include(t => t.School).Include(t => t.StartStation).Include(t => t.Student).Include(t => t.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trip_1 == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip_1
                .Include(t => t.EndStation)
                .Include(t => t.School)
                .Include(t => t.StartStation)
                .Include(t => t.Student)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["EndStationID"] = new SelectList(_context.Station, "StationID", "StationID");
            ViewData["SchoolID"] = new SelectList(_context.School, "SchoolID", "Alias");
            ViewData["StartStationID"] = new SelectList(_context.Station, "StationID", "StationID");
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "UserID");
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleID", "VehicleID");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripID,VehicleID,SchoolID,StudentID,StartStationID,EndStationID,StartTime,EndTime")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EndStationID"] = new SelectList(_context.Station, "StationID", "StationID", trip.EndStationID);
            ViewData["SchoolID"] = new SelectList(_context.School, "SchoolID", "Alias", trip.SchoolID);
            ViewData["StartStationID"] = new SelectList(_context.Station, "StationID", "StationID", trip.StartStationID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "UserID", trip.StudentID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleID", "VehicleID", trip.VehicleID);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trip_1 == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip_1.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["EndStationID"] = new SelectList(_context.Station, "StationID", "StationID", trip.EndStationID);
            ViewData["SchoolID"] = new SelectList(_context.School, "SchoolID", "Alias", trip.SchoolID);
            ViewData["StartStationID"] = new SelectList(_context.Station, "StationID", "StationID", trip.StartStationID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "UserID", trip.StudentID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleID", "VehicleID", trip.VehicleID);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,VehicleID,SchoolID,StudentID,StartStationID,EndStationID,StartTime,EndTime")] Trip trip)
        {
            if (id != trip.TripID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripID))
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
            ViewData["EndStationID"] = new SelectList(_context.Station, "StationID", "StationID", trip.EndStationID);
            ViewData["SchoolID"] = new SelectList(_context.School, "SchoolID", "Alias", trip.SchoolID);
            ViewData["StartStationID"] = new SelectList(_context.Station, "StationID", "StationID", trip.StartStationID);
            ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "UserID", trip.StudentID);
            ViewData["VehicleID"] = new SelectList(_context.Vehicle, "VehicleID", "VehicleID", trip.VehicleID);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trip_1 == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip_1
                .Include(t => t.EndStation)
                .Include(t => t.School)
                .Include(t => t.StartStation)
                .Include(t => t.Student)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trip_1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trip_1'  is null.");
            }
            var trip = await _context.Trip_1.FindAsync(id);
            if (trip != null)
            {
                _context.Trip_1.Remove(trip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
          return (_context.Trip_1?.Any(e => e.TripID == id)).GetValueOrDefault();
        }
    }
}
