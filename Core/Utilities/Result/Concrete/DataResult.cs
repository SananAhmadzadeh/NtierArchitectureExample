using Core.Utilities.Result.Abstract;

namespace Core.Utilities.Result.Concrete
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        public T Data { get; }
        public DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }
        public DataResult(bool success, T data, string message) : base(success, message)
        {
            Data = data;
        }
    }
}
