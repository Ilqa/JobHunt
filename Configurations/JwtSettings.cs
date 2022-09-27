namespace JobHunt.Configurations
{
    public class JwtSettings
    {
        public string Issuer { get; internal set; }
        public string Audience { get; internal set; }
        public char[] Key { get; internal set; }
    }
}
