using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        // Kaç kayda etki ettiğini geriye döner, o yüzden int.

        Task BeginTransaction();
        // Task -> Asenkron metotların voidi gibi düşünülebilir.

        Task CommitTransaction();

        Task RollBackTransaction();
    }
}
