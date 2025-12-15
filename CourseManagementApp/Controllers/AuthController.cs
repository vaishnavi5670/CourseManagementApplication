using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CourseManagementApp.Data;

namespace CourseManagementApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly CourseManagementAppDbContext _context;

        public AuthController(CourseManagementAppDbContext context)
        {
            _context = context;
        }

        #region Admin Login

        // GET: AdminLogin
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        // POST: AdminLogin
        [HttpPost]
        public IActionResult AdminLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Email and password are required!";
                return View();
            }

            // Find admin by email
            var admin = _context.Admins.FirstOrDefault(a => a.Email == email);
            if (admin == null)
            {
                Console.WriteLine("Admin login attempt failed: Admin not found for email " + email);
                ViewBag.Error = "Admin not found!";
                return View();
            }

            // password verification
            if (admin.Password != password)
            {
                ViewBag.Error = "Invalid credentials!";
                return View();
            }

            // Clear any existing session
            HttpContext.Session.Clear();

            // Set session values
            HttpContext.Session.SetString("UserRole", "Admin");
            HttpContext.Session.SetString("UserName", admin.FullName);
            HttpContext.Session.SetInt32("AdminId", admin.AdminId);

            // Redirect to Dashboard
            return RedirectToAction("Index", "Admins");
        }

        #endregion

        #region Student Login

        // GET: StudentLogin
        [HttpGet]
        public IActionResult StudentLogin()
        {
            return View();
        }

        // POST: StudentLogin
        [HttpPost]
        public IActionResult StudentLogin(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ViewBag.Error = "Email is required!";
                return View();
            }

            // Find student by email
            var student = _context.Students.FirstOrDefault(s => s.Email == email);
            if (student == null)
            {
                ViewBag.Error = "Student not found!";
                return View();
            }

            // Clear any existing session
            HttpContext.Session.Clear();

            // Set session values
            HttpContext.Session.SetString("UserRole", "Student");
            HttpContext.Session.SetString("UserName", student.FullName);
            HttpContext.Session.SetInt32("StudentId", student.StudentId);

            return RedirectToAction("Index", "Students");
        }

        #endregion

        #region Logout

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin");
        }

        #endregion
    }
}
