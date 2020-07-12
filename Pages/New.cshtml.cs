using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesFile.Data;
using RazorPagesFile.Models;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesFile.Pages{
    public class NewModel:PageModel{
        private readonly RazorPagesFile.Data.MiniFileContext _context;
        private readonly IWebHostEnvironment _env;
        public NewModel(RazorPagesFile.Data.MiniFileContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MiniFile MiniFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(!MiniFile.FileName.EndsWith(".txt")){
                MiniFile.FileName += ".txt";
            }
            string filePath = _env.ContentRootPath+"\\FileStorage\\"+MiniFile.FileName;
            using(StreamWriter sw = System.IO.File.CreateText(filePath)){
                sw.Write(MiniFile.Content);
            }
            
            _context.MiniFile.Add(MiniFile);

            await _context.SaveChangesAsync();

            return RedirectToPage("./View");
        }
    }
}