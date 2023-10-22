using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Models.ViewModels
{
    public class TabVM
    {
        public SheetVM Sheets { get; set; }
        public List<Tab> Tabs { get; set; }
    }
}
