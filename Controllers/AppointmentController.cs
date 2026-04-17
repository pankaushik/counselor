using Counselor.Data;
using Counselor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Counselor.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AppointmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreateAppointment");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_CreateAppointment", model);
            }

            model.CreatedAt = DateTime.UtcNow;
            _db.Appointments.Add(model);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Appointment scheduled successfully." });
        }
    }
}