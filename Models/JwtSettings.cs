namespace backendPizzaria.Models
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpirationTime { get; set; }
        public string Sender { get; set; }
        public string Audience { get; set; }
    }
}
