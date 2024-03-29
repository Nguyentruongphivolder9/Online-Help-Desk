﻿namespace SharedKernel
{
    public sealed record Error(string Code, string? Description = null)
    {
        public static readonly Error? None = null;
        public static readonly Error NullValue = new("Error.NullValue", "Null value was provided");

        public static implicit operator Result(Error error) => Result.Failure(error, "");
    }
}
