using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Abstract
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
