namespace TN.Modules.Buildings.Shared.Api
{
    public abstract class BaseResponse<T>
    {
        public BaseResponse()
        {
            Code = "00";
            Message = "Success";
            CoreProcessId = Guid.Empty;
        }

        public string Code { get; init; }

        public string Message { get; init; }

        public Guid CoreProcessId { get; init; }

        public long Timestamp { get; set; }

        public abstract T Payload { get; init; }
    }
}
