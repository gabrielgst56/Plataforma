﻿using IFSP.Plataforma.Application.Interfaces;
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
    public class ChatbotController : ApiController
    {
        private readonly IChatbotAppService _chatbotAppService;

        public ChatbotController(
            IChatbotAppService chatbotAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _chatbotAppService = chatbotAppService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Response(_chatbotAppService.GetAll());
        }

        [HttpGet]
        [Route("/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var chatbotViewModel = _chatbotAppService.GetById(id);

            return Response(chatbotViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody]ChatbotViewModel chatbotViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(chatbotViewModel);
            }

            _chatbotAppService.Add(chatbotViewModel);

            return Response(chatbotViewModel);
        }

        [HttpPut]
        [AllowAnonymous]
        public IActionResult Put([FromBody]ChatbotViewModel chatbotViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(chatbotViewModel);
            }

            _chatbotAppService.Update(chatbotViewModel);

            return Response(chatbotViewModel);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public IActionResult Delete(Guid id)
        {
            _chatbotAppService.Remove(id);

            return Response();
        }
    }
}
