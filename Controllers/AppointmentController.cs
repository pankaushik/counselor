using Counselor.Data;
using Counselor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var appointments = await _db.Appointments
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
            return View(appointments);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return PartialView("_EditAppointment", appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Appointment model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_EditAppointment", model);
            }

            var appointment = await _db.Appointments.FindAsync(model.Id);
            if (appointment == null)
            {
                return Json(new { success = false, message = "Appointment not found." });
            }

            appointment.FullName = model.FullName;
            appointment.Email = model.Email;
            appointment.Phone = model.Phone;
            appointment.Service = model.Service;
            appointment.AppointmentDate = model.AppointmentDate;
            appointment.Notes = model.Notes;

            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Appointment updated successfully." });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return Json(new { success = false, message = "Appointment not found." });
            }

            _db.Appointments.Remove(appointment);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = "Appointment deleted successfully." });
        }
    }
}