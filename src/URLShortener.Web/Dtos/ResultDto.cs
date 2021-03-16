namespace URLShortener.Web.Dtos
{
    public class ResultDto<T>
    {
        public T Result { get; set; }
        public bool Succeeded { get; set; }
        public ErrorDto Error { get; set; }
    }
}
