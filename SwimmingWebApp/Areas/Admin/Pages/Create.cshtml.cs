using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SwimmingWebApp.DAL.Data;
using SwimmingWebApp.DAL.Entities;

namespace SwimmingWebApp.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly SwimmingWebApp.DAL.Data.ApplicationDbContext _context;

        public CreateModel(SwimmingWebApp.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SwimmerId"] = new SelectList(_context.Swimmers, "SwimmerId", "FullName");
            return Page();
        }

        [BindProperty]
        public Training Training { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trainings.Add(Training);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
