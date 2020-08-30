using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Models
{
    public class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdLog { get; set; }
        public string Email { get; set; }
        public string MessageException { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public string HelpLink { get; set; }
        public string HResult { get; set; }
        public string SourceException { get; set; }
        public string TargetSite { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
