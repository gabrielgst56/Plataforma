using System;
using System.Collections.Generic;
using IFSP.Plataforma.Application.ViewModels;

namespace IFSP.Plataforma.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        void Add(UserViewModel userViewModel);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel GetById(Guid id);
        void Update(UserViewModel userViewModel);
        void Remove(Guid id);
        bool Login(UserViewModel user);
    }
}
