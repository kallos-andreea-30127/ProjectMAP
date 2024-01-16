using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMAP.Models
{
    public class MedicalImage
    {
        public int MedicalImageID { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int? DiagnosticID { get; set; }
        public int? PacientID { get; set; }
        public int? DoctorID { get; set; }

        public Pacient Pacient { get; set; }
        [ForeignKey("DoctorID")]
        public Doctor Doctor { get; set; }
        public Diagnostic Diagnostic { get; set; }  

    }
}
