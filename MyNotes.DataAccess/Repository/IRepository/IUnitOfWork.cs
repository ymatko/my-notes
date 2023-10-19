using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ISheetRepository Sheet { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IEnumerable<IdentityUser> Users { get; }
        ITabRepository Tab { get; }
        void Save();
    }
}
