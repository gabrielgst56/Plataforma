using IFSP.Plataforma.Domain.Entities;
using System.Text;

namespace IFSP.Plataforma.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
