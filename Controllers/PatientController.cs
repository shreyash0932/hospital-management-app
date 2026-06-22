using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _context.Patients.ToList();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
                return NotFound("Patient not found.");

            return Ok(patient);
        }
        [HttpGet("age/{age}")]
        public IActionResult GetPatientByAge(int age)
        {
            var patients = _context.Patients.Where(p => p.Age == age).ToList();

            if (!patients.Any())
                return NotFound("No patients found");

            return Ok(patients);
        }
        [HttpGet("name/{name}")]
        public IActionResult GetPatientByName(string name)
        {
            var patient = _context.Patients.Where(p => p.Name == name) .ToList();
            if (!patient.Any())
                return NotFound("No records found");
            return Ok(patient);

        }




        [HttpPost]
        public IActionResult CreatePatient([FromBody] Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();

            return Ok(patient);
        }

        
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