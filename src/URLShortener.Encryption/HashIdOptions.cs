namespace URLShortener.Encryption
{
    public class HashIdOptions
    {
        public string Salt { get; set; }
        public string Alphabet { get; set; }
        public int MinLength { get; set; }
    }
}
