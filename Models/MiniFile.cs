using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesFile.Models
{
    public class MiniFile
    {
        public int Id {get;set;}
        [Required]
        [Display(Name = "File Name")]
        public string FileName{get;set;}
        [Display(Name = "File Content")]
        public string Content{get;set;}
        public bool IsCurrentlyEdit{get;set;}
        public DateTime? BeginTime{get;set;}
    }
}