using Application.DTOs.Remarks;
using Application.UseCases.Remarks.Command.CreateRemark;
using Ardalis.ApiEndpoints;
using Infrastructure.sHubs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharedKernel;

namespace Web_Api.Endpoints.Requests
{
    public class CreateRemark : EndpointBaseAsync
     .WithRequest<CreateRemarkCommand>
     .WithActionResult<Result>
    {

        private readonly IMediator Sender;
        public readonly IHubContext<ChatHub> _hubContext;
        public CreateRemark(IMediator sender, IHubContext<ChatHub> hubContext)
        {
            Sender = sender;
            _hubContext = hubContext;
        }


        [HttpPost("api/request/create_remark")]
        public override async Task<ActionResult<Result>> HandleAsync(CreateRemarkCommand command, CancellationToken cancellationToken = default)
        {
            var status = await Sender.Send(command);

            if(status != null)
            {
                var roomId = status.Data.Request.Id.ToString(); // dua tren requestId làm room vì nó unique
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(status.Data, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
                });
                await _hubContext.Clients.Group(roomId).SendAsync("ReceiveMessage", jsonString);
            }
            return status;
        }
    }
}