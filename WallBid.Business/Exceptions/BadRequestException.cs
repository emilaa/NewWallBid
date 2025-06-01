namespace WallBid.Infrastructure.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base() { }

        public BadRequestException(string message) : base(message) { }

        public BadRequestException(string message, Dictionary<string, IEnumerable<string>> errors) : base(message)
        {
            this.Errors = errors;
        }

        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }


        public Dictionary<string, IEnumerable<string>> Errors { get; set; }
    }
}
