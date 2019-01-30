using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotels.Core.Domain;
using Hotels.Infrastructure.EF;

namespace Hotels.Controllers
{
    public class TestsController : Controller
    {
        private readonly HotelsDbContext _context;

        public TestsController(HotelsDbContext context)
        {
            _context = context;
        }

        // GET: Tests
        public async Task<IActionResult> Index()
        {
            var hotelsDbContext = _context.Hotels
                .Include(h => h.Address)
                .Include(h => h.AppUser)
                .Include(h => h.Photos);
            return View(await hotelsDbContext.ToListAsync());
        }

        // GET: Tests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.Address)
                .Include(h => h.AppUser)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Tests/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId");
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            return View();
        }

        // POST: Tests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,Name,Description,PriceMin,PriceMax,ThumbnailPath,AppUserId,AddressId,HotelType")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotel.HotelId = Guid.NewGuid();
                _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", hotel.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", hotel.AppUserId);
            return View(hotel);
        }

        // GET: Tests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", hotel.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", hotel.AppUserId);
            return View(hotel);
        }

        // POST: Tests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("HotelId,Name,Description,PriceMin,PriceMax,ThumbnailPath,AppUserId,AddressId,HotelType")] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelId))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "AddressId", "AddressId", hotel.AddressId);
            ViewData["AppUserId"] = new SelectList(_context.AppUsers, "Id", "Id", hotel.AppUserId);
            return View(hotel);
        }

        // GET: Tests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotels
                .Include(h => h.Address)
                .Include(h => h.AppUser)
                .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Tests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(Guid id)
        {
            return _context.Hotels.Any(e => e.HotelId == id);
        }
    }
}
