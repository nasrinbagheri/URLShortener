namespace URLShortener.Web.Dtos
{
    public class ErrorDto
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object Details { get; set; }
    }
}
