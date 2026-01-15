

namespace Core.Utilities.Exceptions
{
    public class AccountCreationException : Exception
    {
        public AccountCreationException(string message) : base(message) { }
        public AccountCreationException() { }
    }
}
