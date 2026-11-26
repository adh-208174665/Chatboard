using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonkeTransportManagement.Context;
using SonkeTransportManagement.Models;

namespace SonkeTransportManagement.Controllers
{
    public class Approval : Controller
    {
        private readonly ApplicationContext _context;

        public Approval(ApplicationContext context)
        {
            _context = context;
        }
    
        [HttpPost]
        public IActionResult UpdateApproveRequest(int Id, string Comments, string Reject, string Approve)
        {
            var results = _context.requests.Where(i => i.Id == Id).FirstOrDefault();
            if (results != null)
            {               
                results.ApproverComments = Comments;

                if (Reject != null){
                    results.Status = Reject;
                }
                else {
                    results.Status = Approve;
                }

                _context.requests.Update(results);
                _context.SaveChangesAsync();
            }
           
            return RedirectToAction("GetRequestByRoleId");
        }
        public IActionResult GetRequestById(int Id)
        {
            var results = _context.requests.Where(i => i.Id == Id).FirstOrDefault();
            if (results != null)
            {
                ViewBag.FirstName = results.firstname;
                ViewBag.LastName = results.lastname;
                ViewBag.ReturnDate = results.ReturnDate;
                ViewBag.DepatureDate = results.DepatureDate;
                ViewBag.EstimatedKilos = results.EstimatedKilos;
                ViewBag.Section = results.Section;
                ViewBag.Position = results.Position;
                ViewBag.RequesterComments = results.RequesterComments;
                ViewBag.RequestType = results.RequestType;
                ViewBag.Reason = results.Reason;
                @ViewBag.Destination = results.Destination;
                ViewBag.Id = Id;
            }
                return View();
        }
        public async Task<IActionResult> GetRequestByRoleId()
        {
            var list = await _context.requests.ToListAsync();
            return View(list);
        }
    }
}
