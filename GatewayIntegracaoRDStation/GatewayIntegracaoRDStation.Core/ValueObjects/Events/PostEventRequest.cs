namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PostEventRequest<T>
    {
        public string Code { get; set; }
        public T Data { get; set; }

        public PostEventRequest(string code, T data)
        {
            Code = code;
            Data = data;
        }
    }
}
