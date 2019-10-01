using IFSP.Plataforma.Application.Interfaces;
using IFSP.Plataforma.Application.ViewModels;
using IFSP.Plataforma.Domain.Core.Bus;
using IFSP.Plataforma.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IFSP.Plataforma.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly IUserAppService _userAppService;

        public UserController(
            IUserAppService userAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _userAppService = userAppService;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_userAppService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var userViewModel = _userAppService.GetById(id);

            return Response(userViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userViewModel);
            }

            _userAppService.Add(userViewModel);

            return Response(userViewModel);
        }

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Put([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userViewModel);
            }

            _userAppService.Update(userViewModel);

            return Response(userViewModel);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public IActionResult Delete(Guid id)
        {
            _userAppService.Remove(id);

            return Response();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]UserViewModel user)
        {
            return Response(_userAppService.Login(user));
        }
    }
}