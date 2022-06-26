using CaseProject.Core.Common.Abstract;

namespace CaseProject.Core.Common.Concrete
{
    public partial class Result<T> : IResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Result()
        {
        }

        public Result(bool success, string message, T data)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
        }
    }
}
