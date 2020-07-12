using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesFile.Data;
using RazorPagesFile.Models;

namespace RazorPagesFile.Pages.MiniFiles
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesFile.Data.MiniFileContext _context;

        public CreateModel(RazorPagesFile.Data.MiniFileContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MiniFile MiniFile { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MiniFile.Add(MiniFile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
