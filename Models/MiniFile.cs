using System;

namespace RazorPagesFile.Models
{
    public class MiniFile
    {
        public int Id {get;set;}
        public string FileName{get;set;}
        public bool IsCurrentlyEdit{get;set;}
        public DateTime? BeginTime{get;set;}
    }
}