﻿using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using IFSP.Plataforma.Application.Interfaces;
using IFSP.Plataforma.Application.ViewModels;
using IFSP.Plataforma.Domain.Commands.User;
using IFSP.Plataforma.Domain.Core.Bus;
using IFSP.Plataforma.Domain.Core.Notifications;
using IFSP.Plataforma.Domain.Interfaces;
using MediatR;

namespace IFSP.Plataforma.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMediatorHandler Bus;
        private readonly DomainNotificationHandler _notifications;

        public UserAppService(IMapper mapper,
                                  IUserRepository userRepository,
                                  IMediatorHandler bus,
                                  INotificationHandler<DomainNotification> notifications)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _notifications = (DomainNotificationHandler)notifications;
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

        public void Add(UserViewModel userViewModel)
        {
            var addUserCommand = _mapper.Map<AddUserCommand>(userViewModel);
            Bus.SendCommand(addUserCommand);
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

        public bool Login(UserViewModel user)
        {
            var entity = _userRepository.GetByEmail(user.Email);

            if(entity != null)
                return entity.Password == user.Password;

            Bus.RaiseEvent(new DomainNotification("Commit", "Incorrect email."));

            return false;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
