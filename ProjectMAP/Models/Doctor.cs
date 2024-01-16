namespace ProjectMAP.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string ContactInfo { get; set; }
        public string Description { get; set; }
        public int? SpecialtyID { get; set; }


        public ICollection<MedicalImage> MedicalImages {  get; set; }
        public Specialty Specialty { get; set; } 

    }
}
