using Domain.Errors;
using Domain.Results;

namespace MovieReservationAPI.Extensions
{
    public static class ResultExtensions
    {
        public static T Match<T>(
            this Result result,
            Func<T> onSuccess,
            Func<Error,T> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result.Error);
        }

        public static T Match<T>(
            this Result<T> result,
            Func<T> onSuccess,
            Func<Error,T> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result.Error);
        }
    }
}
