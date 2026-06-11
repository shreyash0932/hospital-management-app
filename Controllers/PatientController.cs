
using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
namespace HospitalManagement.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Display
        public IActionResult Index()
        {
            var data = _context.Patients.ToList();
            return View(data);
        }

        // Create GET
        public IActionResult Create()
        {
            return View();
        }

        // Create POST
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            _context.Update(patient);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
      
        public IActionResult Edit(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);


        }

        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();

            TempData["Success"] = "Patient updated successfully.";
            return RedirectToAction("Index");
        }
        public IActionResult Remove(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                TempData["Error"] = "Patient not found.";
                return RedirectToAction("Index");
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            TempData["Success"] = "Patient deleted successfully.";
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var patient = _context.Patients.Find(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }
    }
}
