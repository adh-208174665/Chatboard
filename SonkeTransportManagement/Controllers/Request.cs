using Microsoft.AspNetCore.Mvc;
using SonkeTransportManagement.Context;
using SonkeTransportManagement.Models;
using SonkeTransportManagement.Sevices;
using System.Threading.Tasks;

namespace SonkeTransportManagement.Controllers
{
    public class Request : Controller
    {
        private readonly ApplicationContext _context;
        private readonly EmailService _emailService;
        public Request(ApplicationContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult VehicleRequest()
        {
            return View();
        }
        public IActionResult FlightRequest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveVehicleRequest(string Email,string EstiKilos, string Reason, string returnDate, string DepatureDate, string position, string section, string manager, string firstname, string lastname, string contact, string NumTravellers, string Comments, string destination)
        {
            RequesterRequest request = new RequesterRequest();
            request.EstimatedKilos = EstiKilos;
            request.Reason = Reason;
            request.ReturnDate = returnDate;
            request.DepatureDate = DepatureDate;
            request.Position = position;
            request.Section = section;
            request.Email = Email;
            request.firstname = firstname;
            request.lastname = lastname;
            request.Contact = contact;
            request.NumTravellers = NumTravellers;
            request.RequesterComments = Comments;
            request.Destination = destination;
            request.CreateDate = DateTime.Now.ToString();
            request.CreatedBy = "Charles";
            request.RequestType = "Vehicle Request";
            request.Status = "Pending";

            _emailService.SendEmail(Email, "TMS Notifications", "Hi, Please note you have a vehicle request awaiting approval for "+firstname+ " " + lastname);

            await _context.AddAsync(request);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");           
        }
        [HttpPost]
        public async Task<IActionResult> SaveFlightRequest(string Email,string Reason, string returnDate, string DepatureDate, string position, string section, string manager, string firstname, string lastname, string contact, string NumTravellers, string Comments, string destination)
        {
            RequesterRequest request = new RequesterRequest();
            request.Reason = Reason;
            request.ReturnDate = returnDate;
            request.DepatureDate = DepatureDate;
            request.Position = position;
            request.Section = section;
            request.Email = Email;
            request.firstname = firstname;
            request.lastname = lastname;
            request.Contact = contact;
            request.NumTravellers = NumTravellers;
            request.RequesterComments = Comments;
            request.Destination = destination;
            request.CreateDate = DateTime.Now.ToString();
            request.CreatedBy = "Charles";
            request.RequestType = "Flight Request";
            request.Status = "Pending";

            _emailService.SendEmail(Email, "TMS Notifications", "Hi, Please note you have a Flight booking request awaiting approval for " + firstname + " " + lastname);

            await _context.AddAsync(request);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
