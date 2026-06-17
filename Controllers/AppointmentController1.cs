using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Appointments.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Appointment model)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
                return NotFound();

            appointment.PatientName = model.PatientName;
            appointment.DoctorName = model.DoctorName;
            appointment.AppointmentDate = model.AppointmentDate;

            _context.SaveChanges();

            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
                return NotFound();

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();

            return Ok();
        }
    }
}