namespace PetShop.Petshop.Models
{
    public class TokenOption
    {
        public string Secret { get; set; }
        public int ExpiryDays { get; set; }
        public string AuthenticatorIssuer { get; set; }
        public string AuthenticatorTokenProvider { get; set; }
    }
}
