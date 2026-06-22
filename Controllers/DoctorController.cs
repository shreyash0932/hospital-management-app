using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Doctors.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doctor = _context.Doctors.Find(id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Doctor model)
        {
            var doctor = _context.Doctors.Find(id);

            if (doctor == null)
                return NotFound();

            doctor.Name = model.Name;
            doctor.Specialization = model.Specialization;
            doctor.Phone = model.Phone;

            _context.SaveChanges();

            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.Find(id);

            if (doctor == null)
                return NotFound();

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return Ok();
        }
    }
}
