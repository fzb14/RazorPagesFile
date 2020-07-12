using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesFile.Pages
{
    public class TestModel : PageModel
    {
        private readonly ILogger<TestModel> _logger;
        private readonly IWebHostEnvironment _env;

        public TestModel(ILogger<TestModel> logger,IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult OnGet()
        {
            string contentRootPath = _env.ContentRootPath;
            string webRootPath = _env.WebRootPath;

            string pathBase1 = HttpContext.Request.PathBase;
            string path1 = HttpContext.Request.Path;

            return Content("path:"+path1+"\tpathBae:"+pathBase1+"\nenv:\n"+contentRootPath+"\\1.text" + "\n" + webRootPath);
        }
    }
}
