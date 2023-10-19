using MyNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.DataAccess.Repository.IRepository
{
    public interface ITabRepository : IRepository<Tab>
    {
        void Update(Tab obj);
    }
}
