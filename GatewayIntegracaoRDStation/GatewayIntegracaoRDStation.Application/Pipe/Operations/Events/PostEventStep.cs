using GatewayIntegracaoRDStation.Core.Resources;
using GatewayIntegracaoRDStation.Core.ValueObjects.Events;
using Mvp24Hours.Core.Contract.Infrastructure.Pipe;
using Mvp24Hours.Extensions;
using Mvp24Hours.Helpers;
using Mvp24Hours.Infrastructure.Pipe.Operations;
using Newtonsoft.Json;
using System.Collections;
using System.Threading.Tasks;

namespace GatewayIntegracaoRDStation.Application.Pipe.Operations.Events
{
    public class PostEventStep : OperationBaseAsync
    {
        public override async Task ExecuteAsync(IPipelineMessage input)
        {
            if (!input.HasContent("urlBase"))
            {
                input.Messages.AddMessage("rdstation_urlBase", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (!input.HasContent("data"))
            {
                input.Messages.AddMessage("data", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (!input.HasContent("accessToken"))
            {
                input.Messages.AddMessage("accessToken", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (input.IsFaulty)
            {
                return;
            }

            var urlBase = input.GetContent<string>("urlBase");
            var data = input.GetContent<object>("data");
            var accessToken = input.GetContent<string>("accessToken");

            var header = new Hashtable(); header.Add("Authorization", $"Bearer {accessToken}");

            var json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var url = $"{urlBase}/platform/events";
            var response = await WebRequestHelper.PostAsync(url, json, header);

            var error = response.ToDeserialize<PostEventErrorResponse>();

            if (error.Errors.AnyOrNotNull())
            {
                input.Messages.AddMessage("post_events", Messages.OPERATION_FAIL, Mvp24Hours.Core.Enums.MessageType.Error);
                return;
            }

            var result = response.ToDeserialize<PostEventResponse>();

            input.AddContent("postEventResponse", result);
        }
    }
}
