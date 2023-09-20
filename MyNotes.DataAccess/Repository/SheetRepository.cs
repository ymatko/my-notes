using MyNotes.DataAccess.Data;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Repository
{
    public class SheetRepository : Repository<Sheet>, ISheetRepository
    {
        private ApplicationDbContext _db;
        public SheetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Sheet obj)
        {
            _db.Sheets.Update(obj);
        }
    }
}
