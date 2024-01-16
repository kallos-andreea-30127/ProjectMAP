namespace ProjectMAP.Models
{
    public class Diagnostic
    {
        public int DiagnosticID { get; set; }
        public string DiagnosticName { get; set; }
        public string Description { get; set; }

        public ICollection<MedicalImage> MedicalImages { get; set; }

    }
}
