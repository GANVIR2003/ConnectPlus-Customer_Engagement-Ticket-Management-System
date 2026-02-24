namespace ConnectPlus.API.Exceptions
{
    public class InvalidStatusTransitionException : Exception
    {
        public InvalidStatusTransitionException(string message)
            : base(message)
        {
        }
    }
}