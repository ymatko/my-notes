using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IEnumerable<IdentityUser> Users { get; private set; }
        public ITabRepository Tab { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Sheet = new SheetRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Tab = new TabRepository(_db);
            Users = db.Users;
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
