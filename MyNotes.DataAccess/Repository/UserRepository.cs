using Microsoft.AspNetCore.Identity;
using MyNotes.DataAccess.Data;
using MyNotes.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Repository
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        private ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(IdentityUser user)
        {
            _db.Users.Update(user);
        }
    }
}
