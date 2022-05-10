namespace IdentityDemo.Api.Interfaces.Base
{
    public interface IServiceResult<T>
    {
        T Value { get; }

        int ErrorCode { get; }

        int Status { get; }

        bool IsSuccess { get; }
    }

    public interface IServiceResult
    {
        int ErrorCode { get; }

        int Status { get; }

        bool IsSuccess { get; }
    }
}
