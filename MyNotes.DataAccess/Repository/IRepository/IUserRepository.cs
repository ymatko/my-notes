using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<IdentityUser>
    {
        public void Update(IdentityUser user);
    }
}
