namespace HospitalManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }

        public string? Gender { get; set; }

        public string? Disease { get; set; }

        public string? DoctorName { get; set; }

        public string? City { get; set; }
    }
}
