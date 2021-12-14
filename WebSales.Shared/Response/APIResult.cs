namespace WebSales.Shared.Response
{
    public struct APIResult<TFailure, TSuccess>
    {
        public bool Succeeded { get; set; }
        public TFailure Failure { get; set; }
        public TSuccess Success { get; set; }

        public APIResult(TFailure failure)
        {
            Succeeded = false;
            Failure = failure;
            Success = default;
        }
        public APIResult(TSuccess success)
        {
            Succeeded = true;
            Failure = default;
            Success = success;
        }

        public static implicit operator APIResult<TFailure, TSuccess>(TFailure failure)
        {
            return new(failure);
        }

        public static implicit operator APIResult<TFailure, TSuccess>(TSuccess success)
        {
            return new(success);
        }
    }
}
