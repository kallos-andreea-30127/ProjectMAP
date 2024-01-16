namespace ProjectMAP.Models
{
    public class Pacient
    {
        public int PacientID { get; set; }
        public string PacientName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsInsured { get; set; }

        public ICollection<MedicalImage> MedicalImages { get; set; }

    }
}
