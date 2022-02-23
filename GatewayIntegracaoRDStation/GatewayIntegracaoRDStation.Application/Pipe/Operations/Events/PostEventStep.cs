using GatewayIntegracaoRDStation.Core.Resources;
using GatewayIntegracaoRDStation.Core.ValueObjects.Authentication;
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
        public override async Task<IPipelineMessage> ExecuteAsync(IPipelineMessage input)
        {
            if (!input.HasContent("urlBase"))
            {
                NotificationContext.Add("PostEventMapperResponseStep", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (!input.HasContent("data"))
            {
                NotificationContext.Add("PostEventMapperResponseStep", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (!input.HasContent("accessTokenResponse"))
            {
                NotificationContext.Add("PostEventMapperResponseStep", Messages.RECORD_NOT_FOUND, Mvp24Hours.Core.Enums.MessageType.Error);
            }

            if (NotificationContext.HasErrorNotifications)
            {
                input.SetLock();
                return input;
            }

            var urlBase = input.GetContent<string>("urlBase");
            var data = input.GetContent<object>("data");
            var accessTokenResponse = input.GetContent<AccessTokenResponse>("accessTokenResponse");

            var header = new Hashtable(); header.Add("Authorization", $"Bearer {accessTokenResponse.AccessToken}");

            var body = JsonConvert.SerializeObject(data);

            var response = await WebRequestHelper.PostAsync($"{urlBase}/platform/events", body, header);

            var result = response.ToDeserialize<PostEventResponse>();

            if (result != null)
            {
                input.AddContent("postEventResponse", result);
            }

            return input;
        }
    }
}
