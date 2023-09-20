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
        void Save();
    }
}
