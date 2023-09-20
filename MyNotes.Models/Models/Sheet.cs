using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Models.Models
{
    public class Sheet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }
        public string? Text { get; set; }
    }
}
