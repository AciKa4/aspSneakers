 namespace AspSneakers.Api.Core
{
    public class AppSettings
    {
        public string ConnString { get; set; }
        public string EmailFrom { get; set; }
        public string EmailPassword { get; set; }
        public JwtSettings JwtSettings { get; set; }
    }
}
