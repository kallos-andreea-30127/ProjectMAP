namespace ProjectMAP.Models
{
    public class Specialty
    {
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set;}
        public string Abbreviation { get; set;}

        public ICollection<Doctor> Doctors { get; set; }

    }
}
