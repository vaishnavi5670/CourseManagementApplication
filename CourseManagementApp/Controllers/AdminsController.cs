using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseManagementApp.Data;
using CourseManagementApp.Models;

namespace CourseManagementApp.Controllers
{
    [AuthorizeRole("Admin")]
    public class AdminsController : Controller
    {
        private readonly CourseManagementAppDbContext _context;

        public AdminsController(CourseManagementAppDbContext context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Admins.ToListAsync());
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);

            if (admin == null)
                return NotFound();

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Admin admin)
        {
            if (!ModelState.IsValid)
                return View(admin);

            // No hashing needed, store plain password
            // Make sure your model now has Password property, not PasswordHash
            _context.Add(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
                return NotFound();

            return View(admin);
        }

        // POST: Admins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Admin admin)
        {
            if (id != admin.AdminId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(admin);

            var existingAdmin = await _context.Admins.FindAsync(id);
            if (existingAdmin == null)
                return NotFound();

            // Update fields
            existingAdmin.FullName = admin.FullName;
            existingAdmin.Email = admin.Email;
            existingAdmin.Phone = admin.Phone;

            // Update password if entered
            if (!string.IsNullOrWhiteSpace(admin.Password))
            {
                existingAdmin.Password = admin.Password; // Plain password
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.AdminId == id);

            if (admin == null)
                return NotFound();

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.AdminId == id);
        }
    }
}
