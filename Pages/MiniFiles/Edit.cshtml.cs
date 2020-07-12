using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesFile.Data;
using RazorPagesFile.Models;

namespace RazorPagesFile.Pages.MiniFiles
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesFile.Data.MiniFileContext _context;

        public EditModel(RazorPagesFile.Data.MiniFileContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MiniFile MiniFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MiniFile = await _context.MiniFile.FirstOrDefaultAsync(m => m.Id == id);

            if (MiniFile == null)
            {
                return NotFound();
            }
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

            _context.Attach(MiniFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiniFileExists(MiniFile.Id))
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

        private bool MiniFileExists(int id)
        {
            return _context.MiniFile.Any(e => e.Id == id);
        }
    }
}
