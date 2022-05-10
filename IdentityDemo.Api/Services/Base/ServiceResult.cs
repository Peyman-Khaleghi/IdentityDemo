using IdentityDemo.Api.Interfaces.Base;

namespace IdentityDemo.Api.Services.Base
{
    public class ServiceResult<T> : IServiceResult<T>
    {
        public T Value { get; init; }

        public int ErrorCode { get; init; }

        public int Status { get; init; }

        public bool IsSuccess => Status % 100 == 2;

        public static ServiceResult<T> Ok(T value)
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status200OK,
                Value = value
            };
        }

        public static ServiceResult<T> NotFound()
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status404NotFound
            };
        }

        public static ServiceResult<T> BadRequest(ErrorCode code)
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status400BadRequest,
                ErrorCode = (int)code
            };
        }

        public static ServiceResult<T> Created(T value)
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status201Created,
                Value = value
            };
        }
    }

    public class ServiceResult : IServiceResult
    {
        public int ErrorCode { get; init; }

        public int Status { get; init; }

        public bool IsSuccess => Status % 100 == 1;

        public static ServiceResult Ok()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status200OK,
            };
        }

        public static ServiceResult NotFound()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status404NotFound
            };
        }

        public static ServiceResult BadRequest(ErrorCode code)
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status400BadRequest,
                ErrorCode = (int)code
            };
        }

        public static ServiceResult Created()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status201Created
            };
        }

        public static ServiceResult Accepted()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status202Accepted
            };
        }

        public static ServiceResult NoContent()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status204NoContent
            };
        }
    }

}
