namespace Core.Utilities.Result.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult() : base(true, default) { }
        public SuccessDataResult(T data) : base(true, data) { }
        public SuccessDataResult(T data, string message) : base(true, data, message) { }
        public SuccessDataResult(string message) : base(true, default, message) { }
    }
}
