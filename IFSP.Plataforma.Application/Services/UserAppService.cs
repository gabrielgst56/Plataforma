using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using IFSP.Plataforma.Application.Interfaces;
using IFSP.Plataforma.Application.ViewModels;
using IFSP.Plataforma.Domain.Commands.User;
using IFSP.Plataforma.Domain.Core.Bus;
using IFSP.Plataforma.Domain.Interfaces;

namespace IFSP.Plataforma.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler Bus;

        public UserAppService(IMapper mapper,
                                  IUserRepository userRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            Bus = bus;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider);
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }

        public void Register(UserViewModel userViewModel)
        {
            var registerCommand = _mapper.Map<AddUserCommand>(userViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(UserViewModel userViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(userViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
