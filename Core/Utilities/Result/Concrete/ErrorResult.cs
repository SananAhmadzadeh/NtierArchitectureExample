namespace Core.Utilities.Result.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(bool success) : base(false) { }
        public ErrorResult(string message) : base(false, message) { }
    }
}
