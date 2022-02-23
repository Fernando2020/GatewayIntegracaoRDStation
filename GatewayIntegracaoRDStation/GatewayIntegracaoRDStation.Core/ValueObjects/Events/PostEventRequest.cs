namespace GatewayIntegracaoRDStation.Core.ValueObjects.Events
{
    public class PostEventRequest<T>
    {
        public T Data { get; set; }

        public PostEventRequest(T data)
        {
            Data = data;
        }
    }
}
