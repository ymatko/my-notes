using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Models.ViewModels
{
    public class SheetVM
    {
        public List<Sheet> UserSheets { get; set; }
        public List<Sheet> AdminSheets { get; set; }
    }
}
