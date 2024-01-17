using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectMAP.Data;
using ProjectMAP.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProjectMAP.Controllers
{
    public class MedicalImagesController : Controller
    {
        private readonly ClinicContext _context;

        public MedicalImagesController(ClinicContext context)
        {
            _context = context;
        }

        // GET: MedicalImages
        public async Task<IActionResult> Index(string sortOrder,string currentFilter,string searchString,int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParam"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var medicalImages = from m in _context.MedicalImages.Include(i=>i.Doctor).Include(i=>i.Pacient).Include(i=>i.Diagnostic)
                                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                medicalImages = medicalImages.Where(p => p.Pacient.PacientName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    medicalImages = medicalImages.OrderByDescending(m => m.Date);
                    break;
                default: break;
            }

            int pageSize = 3;
            return View(await PaginatedList<MedicalImage>.CreateAsync(medicalImages.AsNoTracking(), pageNumber ??1, pageSize));
        }

        // GET: MedicalImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MedicalImages == null)
            {
                return NotFound();
            }

            var medicalImage = await _context.MedicalImages
                .Include(m => m.Diagnostic)
                .Include(m => m.Doctor)
                .Include(m => m.Pacient)
                .FirstOrDefaultAsync(m => m.MedicalImageID == id);
            if (medicalImage == null)
            {
                return NotFound();
            }

            return View(medicalImage);
        }

        // GET: MedicalImages/Create
        public IActionResult Create()
        {
            ViewData["DiagnosticID"] = new SelectList(_context.Diagnostics, "DiagnosticID", "DiagnosticID");
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorID");
            ViewData["PacientID"] = new SelectList(_context.Pacients, "PacientID", "PacientID");
            return View();
        }

        // POST: MedicalImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalImageID,Type,Date,DiagnosticID,PacientID,DoctorID")] MedicalImage medicalImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosticID"] = new SelectList(_context.Diagnostics, "DiagnosticID", "DiagnosticID", medicalImage.DiagnosticID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorID", medicalImage.DoctorID);
            ViewData["PacientID"] = new SelectList(_context.Pacients, "PacientID", "PacientID", medicalImage.PacientID);
            return View(medicalImage);
        }

        // GET: MedicalImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MedicalImages == null)
            {
                return NotFound();
            }

            var medicalImage = await _context.MedicalImages.FindAsync(id);
            if (medicalImage == null)
            {
                return NotFound();
            }
            ViewData["DiagnosticID"] = new SelectList(_context.Diagnostics, "DiagnosticID", "DiagnosticID", medicalImage.DiagnosticID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorID", medicalImage.DoctorID);
            ViewData["PacientID"] = new SelectList(_context.Pacients, "PacientID", "PacientID", medicalImage.PacientID);
            return View(medicalImage);
        }

        // POST: MedicalImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalImageID,Type,Date,DiagnosticID,PacientID,DoctorID")] MedicalImage medicalImage)
        {
            if (id != medicalImage.MedicalImageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalImageExists(medicalImage.MedicalImageID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiagnosticID"] = new SelectList(_context.Diagnostics, "DiagnosticID", "DiagnosticID", medicalImage.DiagnosticID);
            ViewData["DoctorID"] = new SelectList(_context.Doctors, "DoctorID", "DoctorID", medicalImage.DoctorID);
            ViewData["PacientID"] = new SelectList(_context.Pacients, "PacientID", "PacientID", medicalImage.PacientID);
            return View(medicalImage);
        }

        // GET: MedicalImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MedicalImages == null)
            {
                return NotFound();
            }

            var medicalImage = await _context.MedicalImages
                .Include(m => m.Diagnostic)
                .Include(m => m.Doctor)
                .Include(m => m.Pacient)
                .FirstOrDefaultAsync(m => m.MedicalImageID == id);
            if (medicalImage == null)
            {
                return NotFound();
            }

            return View(medicalImage);
        }

        // POST: MedicalImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MedicalImages == null)
            {
                return Problem("Entity set 'ClinicContext.MedicalImages'  is null.");
            }
            var medicalImage = await _context.MedicalImages.FindAsync(id);
            if (medicalImage != null)
            {
                _context.MedicalImages.Remove(medicalImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalImageExists(int id)
        {
          return (_context.MedicalImages?.Any(e => e.MedicalImageID == id)).GetValueOrDefault();
        }
    }
}
