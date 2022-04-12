using CrossCuttingLayer;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace Microservice.TodoApp.Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public TodoController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTicket(Todo11 todoModel)
        {
            if (todoModel is not null)
            {
                
                var endpoint = await _sendEndpointProvider.GetSendEndpoint(GenerateUriAddress("test____todoQueue11"));

                await endpoint.Send(todoModel, context => context.SetPriority((byte)4));

                return Ok(); 
            }
            return BadRequest();
        }

        private Uri GenerateUriAddress(string exchangeName)
        {
            return new Uri($"exchange:{exchangeName}?type={ExchangeType.Direct}");
        }
    } 
}