using MyNotes.DataAccess.Data;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Repository
{
    public class TabRepository : Repository<Tab>, ITabRepository
    {
        private ApplicationDbContext _db;
        public TabRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Tab obj)
        {
            _db.Tabs.Update(obj);
        }
    }
}
