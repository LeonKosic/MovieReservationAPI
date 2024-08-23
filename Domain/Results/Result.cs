using Domain.Errors;

namespace Domain.Results
{

    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid Error", nameof(error));
            }
            IsSuccess = isSuccess; Error = error;
        }
        public bool IsSuccess { get; }
        public Error Error { get; }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);
    }
    public class Result<T>:Result
    {
        protected Result(T? value, bool isSuccess, Error error):base(isSuccess, error) => Value = value; 
        
        public T? Value { get;}

        public static Result<T> Success(T val) => new(val, true, Error.None);
        new public static Result<T> Failure(Error error) => new (default,false, error);
    }
}
