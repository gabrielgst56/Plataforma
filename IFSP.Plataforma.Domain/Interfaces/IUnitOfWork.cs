using System;
using System.Collections.Generic;
using System.Text;

namespace IFSP.Plataforma.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
