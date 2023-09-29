using MyNotes.DataAccess.Data;
using MyNotes.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ISheetRepository Sheet { get; private set; }
        public IUserRepository User { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Sheet = new SheetRepository(_db);
            User = new UserRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
