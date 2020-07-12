using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFile.Data;
using RazorPagesFile.Models;

namespace RazorPagesFile.Pages.MiniFiles
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesFile.Data.MiniFileContext _context;

        public DeleteModel(RazorPagesFile.Data.MiniFileContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MiniFile = await _context.MiniFile.FindAsync(id);

            if (MiniFile != null)
            {
                _context.MiniFile.Remove(MiniFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
