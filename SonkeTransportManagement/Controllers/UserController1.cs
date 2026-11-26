using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SonkeTransportManagement.Context;
using SonkeTransportManagement.Models;
using SonkeTransportManagement.Sevices;
using System.Xml.Linq;

namespace SonkeTransportManagement.Controllers
{
    public class UserController1 : Controller
    {
        private readonly ApplicationContext _context;
        private readonly EmailService _emailService;
        public UserController1(ApplicationContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public IActionResult CreateUser()
        {
            var roles = _context.roles.ToList(); // Fetch from DB
            ViewData["RoleList"] = new SelectList(roles, "Id", "Descpription");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveUser(int Id,string Email,string position, string section, string firstname, string lastname, string contact)
        {
            User user = new User();

            user.Position = position;
            user.Section = section;
            user.RoleId = Id;
            user.Email = Email;
            user.Firstname = firstname;
            user.Lastname = lastname;
            user.Contact = contact;
            user.CreateDate = DateTime.Now.ToString();
            user.CreatedBy = "Charles";

            Random rnd = new Random();

            // Random integer between 0 and 99
            int randomInt = rnd.Next(0, 100);
            var password = firstname + lastname + randomInt.ToString();
            user.UserPassword = password;

            _emailService.SendEmail(Email, "Account Logins", "Hello your Username is: "+ Email + " and password is: "+ password);


            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("GetUser");

        }
        [HttpGet]
        public IActionResult GetUser()
        {
            return View();
        }
    }
}
