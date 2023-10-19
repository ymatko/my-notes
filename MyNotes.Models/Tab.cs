using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Models
{
    public class Tab
    {
        [Key]
        public int Id { get; set; }
        public List<Sheet> Sheets { get; set; }

    }
}
