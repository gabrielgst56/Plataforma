using IFSP.Plataforma.Domain.Entities;
using IFSP.Plataforma.Domain.Interfaces;
using IFSP.Plataforma.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IFSP.Plataforma.Infra.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context)
            : base(context)
        {

        }

        public User GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
