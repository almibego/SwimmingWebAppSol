using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SwimmingWebApp.DAL.Data;
using SwimmingWebApp.DAL.Entities;

namespace SwimmingWebApp.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly SwimmingWebApp.DAL.Data.ApplicationDbContext _context;

        public EditModel(SwimmingWebApp.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Training Training { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training = await _context.Trainings
                .Include(t => t.Swimmer).FirstOrDefaultAsync(m => m.TrainingId == id);

            if (Training == null)
            {
                return NotFound();
            }
           ViewData["SwimmerId"] = new SelectList(_context.Swimmers, "SwimmerId", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Training).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingExists(Training.TrainingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrainingExists(int id)
        {
            return _context.Trainings.Any(e => e.TrainingId == id);
        }
    }
}
