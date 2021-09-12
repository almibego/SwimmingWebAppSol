using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SwimmingWebApp.DAL.Data;
using SwimmingWebApp.DAL.Entities;

namespace SwimmingWebApp.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly SwimmingWebApp.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(SwimmingWebApp.DAL.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Training = await _context.Trainings.FindAsync(id);

            if (Training != null)
            {
                _context.Trainings.Remove(Training);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
