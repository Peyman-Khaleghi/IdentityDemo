using IdentityDemo.Api.Interfaces.Base;

namespace IdentityDemo.Api.Services.Base
{
    public class ServiceResult<T> : IServiceResult<T>
    {
        public T Value { get; init; }

        public int ErrorCode { get; init; }

        public int Status { get; init; }

        public bool IsSuccess { get; set; }

        public static ServiceResult<T> Ok(T value)
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status200OK,
                Value = value,
                IsSuccess = true,
            };
        }

        public static ServiceResult<T> NotFound()
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status404NotFound,
                IsSuccess = false,
            };
        }

        public static ServiceResult<T> BadRequest(ErrorCode code)
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status400BadRequest,
                ErrorCode = (int)code,
                IsSuccess = false,
            };
        }

        public static ServiceResult<T> Created(T value)
        {
            return new ServiceResult<T>
            {
                Status = StatusCodes.Status201Created,
                Value = value,
                IsSuccess = true,
            };
        }
    }

    public class ServiceResult : IServiceResult
    {
        public int ErrorCode { get; init; }

        public int Status { get; init; }

        public bool IsSuccess { get; set; }

        public static ServiceResult Ok()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status200OK,
                IsSuccess = true,
            };
        }

        public static ServiceResult NotFound()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status404NotFound,
                IsSuccess = false,
            };
        }

        public static ServiceResult BadRequest(ErrorCode code)
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status400BadRequest,
                ErrorCode = (int)code,
                IsSuccess = false,
            };
        }

        public static ServiceResult Created()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status201Created,
                IsSuccess = true,
            };
        }

        public static ServiceResult Accepted()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status202Accepted,
                IsSuccess = true,
            };
        }

        public static ServiceResult NoContent()
        {
            return new ServiceResult
            {
                Status = StatusCodes.Status204NoContent,
                IsSuccess =true,
            };
        }
    }

}
