using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/patient
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _context.Patients.ToList();
            return Ok(patients);
        }

        // GET: api/patient/1
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound("Patient not found.");

            return Ok(patient);
        }

        // POST: api/patient
        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return Ok(patient);
        }

        // PUT: api/patient/1
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Patient patient)
        {
            var existingPatient = _context.Patients.Find(id);

            if (existingPatient == null)
                return NotFound("Patient not found.");

            existingPatient.Name = patient.Name;
            existingPatient.Age = patient.Age;
            existingPatient.Gender = patient.Gender;
            existingPatient.Disease = patient.Disease;
            existingPatient.DoctorName = patient.DoctorName;
            existingPatient.City = patient.City;

            _context.SaveChanges();

            return Ok(existingPatient);
        }

        // DELETE: api/patient/1
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound("Patient not found.");

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return Ok("Patient deleted successfully.");
        }
    }
}