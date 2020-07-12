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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFile.Data.MiniFileContext _context;

        public IndexModel(RazorPagesFile.Data.MiniFileContext context)
        {
            _context = context;
        }

        public IList<MiniFile> MiniFile { get;set; }

        public async Task OnGetAsync()
        {
            MiniFile = await _context.MiniFile.ToListAsync();
        }
    }
}
