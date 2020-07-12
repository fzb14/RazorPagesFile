using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFile.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace RazorPagesFile.Pages
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesFile.Data.MiniFileContext _context;
        private readonly IWebHostEnvironment _env;

        public EditModel(RazorPagesFile.Data.MiniFileContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
            else if(MiniFile.IsCurrentlyEdit==true && (MiniFile.BeginTime??DateTime.Now).AddMinutes(1)>DateTime.Now)
            {
                return RedirectToPage("./Lock");
            }
            else{
                string filePath = _env.ContentRootPath+"\\FileStorage\\"+MiniFile.FileName;
                MiniFile.Content = System.IO.File.ReadAllText(filePath);
                MiniFile.IsCurrentlyEdit = true;
                MiniFile.BeginTime = DateTime.Now;
                _context.Attach(MiniFile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string filePath = _env.ContentRootPath+"\\FileStorage\\"+MiniFile.FileName;
            using(StreamWriter sw = System.IO.File.CreateText(filePath)){
                sw.Write(MiniFile.Content);
            }
            MiniFile.IsCurrentlyEdit = false;
            MiniFile.BeginTime = null;
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

            return RedirectToPage("./View");
        }

        private bool MiniFileExists(int id)
        {
            return _context.MiniFile.Any(e => e.Id == id);
        }
    }
}