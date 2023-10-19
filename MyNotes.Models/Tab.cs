using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Models
{
    public class Tab
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }

        [ForeignKey("Sheet")]
        public int SheetId { get; set; }
        public Sheet Sheet { get; set; }
    }
}
