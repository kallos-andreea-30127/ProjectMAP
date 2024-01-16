using Microsoft.EntityFrameworkCore;
using ProjectMAP.Models;

namespace ProjectMAP.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ClinicContext(serviceProvider.GetRequiredService<DbContextOptions<ClinicContext>>()))
            {
                if (context.Doctors.Any())
                {
                    return; // BD a fost creata anterior
                }

                context.Pacients.AddRange(
                    new Pacient
                    {
                        PacientName = "John Doe",
                        Age = 40,
                        Email = "jd@mail.com",
                        Phone = "+121234567890",
                        IsInsured = true
                    },
                    new Pacient
                    {
                        PacientName = "Jane Soe",
                        Age = 32,
                        Email = "js@mail.com",
                        Phone = "+122345678901",
                        IsInsured = true
                    },
                    new Pacient
                    {
                        PacientName = "Alice Wonder",
                        Age = 10,
                        Email = "aw@mail.com",
                        Phone = "+123456789012",
                        IsInsured = true
                    },
                    new Pacient
                    {
                        PacientName = "Roy Dain",
                        Age = 20,
                        Email = "rd@mail.com",
                        Phone = "+124567890123",
                        IsInsured = true
                    },
                    new Pacient
                    {
                        PacientName = "Diana Siemens",
                        Age = 55,
                        Email = "ds@mail.com",
                        Phone = "+125678901234",
                        IsInsured = true
                    },
                    new Pacient
                    {
                        PacientName = "Amir Mijad",
                        Age = 29,
                        Email = "am@mail.com",
                        Phone = "+126789012345",
                        IsInsured = false
                    });
                context.SaveChanges();

                context.AddRange(
                    new Specialty
                    {
                        SpecialtyName = "General Surgery",
                        Abbreviation = "GEN"
                    },
                    new Specialty
                    {
                        SpecialtyName = "Cardiothoracic Surgery",
                        Abbreviation = "CARDIO"
                    },
                    new Specialty
                    {
                        SpecialtyName = "Orthopedic Surgery",
                        Abbreviation = "ORTHO"
                    },
                    new Specialty
                    {
                        SpecialtyName = "Pediatric Surgery",
                        Abbreviation = "PEDS"
                    });
                context.SaveChanges();

                context.Diagnostics.AddRange(
                    new Diagnostic
                    {
                        DiagnosticName = "Osteoarthritis",
                        Description = "Degenerative joint disease that results from breakdown of joint cartilage and underlying bone."
                    },
                    new Diagnostic
                    {
                        DiagnosticName = "Proximal radius fracture",
                        Description = "A fracture within the capsule of the elbow joint results in the fat pad sign or sail sign which is a displacement of the fat pad at the elbow."
                    },
                    new Diagnostic
                    {
                        DiagnosticName = "Stenosis",
                        Description = "Abnormal narrowing of a blood vessel or other tubular organ or structure such as foramina and canals. It is also sometimes called a stricture."
                    }, 
                    new Diagnostic
                    {
                        DiagnosticName = "Cerebral aneurysm",
                        Description = "Cerebrovascular disorder in which weakness in the wall of a cerebral artery or vein causes a localized dilation or ballooning of the blood vessel."
                    },
                    new Diagnostic
                    {
                        DiagnosticName = "Appendicitis",
                        Description = "Appendicitis is inflammation of the appendix"
                    }
                    );
                context.SaveChanges();

                context.Doctors.AddRange(
                new Doctor
                {
                    DoctorName = "Meredith Grey",
                    ContactInfo = "mg@seattlegrace.com",
                    Description = "General Surgeon, ",
                    SpecialtyID = 1
                },
                new Doctor
                {
                    DoctorName = "Cristina Yang",
                    ContactInfo = "cy@seattlegrace.com",
                    Description = "Attending Cardiothoracic Surgeon",
                    SpecialtyID = 2
                },
                new Doctor
                {
                    DoctorName = "Calliope Torres",
                    ContactInfo = "ct@seattlegrace.com",
                    Description = "Chief of Orthopedic Surgery",
                    SpecialtyID = 3
                },
                new Doctor
                {
                    DoctorName = "Arizona Robbins",
                    ContactInfo = "ar@seattlegrace.com",
                    Description = "Chief of Pediatric Surgery",
                    SpecialtyID = 4
                });
                context.SaveChanges();

                context.MedicalImages.AddRange(
                    new MedicalImage
                    {
                        Type = "",
                        Date = DateTime.Parse("2024-01-08"),
                        DiagnosticID = 1,
                        PacientID = 2,
                        DoctorID = 3
                    },
                    new MedicalImage
                    {
                        Type = "",
                        Date = DateTime.Parse("2024-01-07"),
                        DiagnosticID = 1,
                        PacientID = 2,
                        DoctorID = 3
                    },
                    new MedicalImage
                    {
                        Type = "",
                        Date = DateTime.Parse("2024-01-09"),
                        DiagnosticID = 1,
                        PacientID = 2,
                        DoctorID = 3
                    },
                    new MedicalImage
                    {
                        Type = "",
                        Date = DateTime.Parse("2024-01-08"),
                        DiagnosticID = 1,
                        PacientID = 2,
                        DoctorID = 3
                    },
                    new MedicalImage
                    {
                        Type = "",
                        Date = DateTime.Parse("2024-01-09"),
                        DiagnosticID = 1,
                        PacientID = 2,
                        DoctorID = 3
                    },
                    new MedicalImage
                    {
                        Type = "",
                        Date = DateTime.Parse("2024-01-09"),
                        DiagnosticID = 1,
                        PacientID = 2,
                        DoctorID = 3
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
