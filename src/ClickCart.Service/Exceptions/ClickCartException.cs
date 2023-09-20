namespace ClickCart.Service.Exceptions
{
    public class ClickCartException : Exception
    {
        public int statusCode { get; set; }
        public ClickCartException(int code, string message) : base(message)
        {
            this.statusCode = code;
        }
    }
}
