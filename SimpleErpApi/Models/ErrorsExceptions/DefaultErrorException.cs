namespace SimpleErpApi.ErrorsExceptions
{
  public class DefaultErrorException : Exception
  {
    public int StatusCode { get; }

    public DefaultErrorException(string message)
      : base(message)
    {
      StatusCode = 500;
    }

    public DefaultErrorException(string message, int statusCode)
      : base(message)
    {
      StatusCode = statusCode;
    }
  }
}
