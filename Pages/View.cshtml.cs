using RazorPagesFile.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesFile.Pages
{
    public class ViewModel : PageModel
    {
        private readonly RazorPagesFile.Data.MiniFileContext _context;

        public ViewModel(RazorPagesFile.Data.MiniFileContext context)
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