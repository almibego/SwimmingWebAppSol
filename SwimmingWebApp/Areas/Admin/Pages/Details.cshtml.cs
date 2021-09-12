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
    public class DetailsModel : PageModel
    {
        private readonly SwimmingWebApp.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(SwimmingWebApp.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
