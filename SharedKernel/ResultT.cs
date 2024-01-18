namespace SharedKernel
{
    public class Result<TValue> : Result
    {
        private readonly TValue? _data;
        protected internal Result(TValue? data, bool isSuccess, string statusMessage, Error? error) 
            : base(isSuccess, statusMessage, error)
        {
            _data = data;
        }

        public TValue Data => IsSuccess
            ? _data!
            : throw new InvalidOperationException("The value of a failure result can't be accessed");

        public static implicit operator Result<TValue>(TValue? data) =>
            data is not null ? Success(data) : Failure<TValue>(Error.NullValue);
    }
}
