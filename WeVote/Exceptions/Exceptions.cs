namespace WeVote.Exceptions
{
    public class DBException: Exception
    {
        public DBException(string? message) : base(message) { }
    }
}
