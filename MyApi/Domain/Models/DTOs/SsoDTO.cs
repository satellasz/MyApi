namespace MyApi.Domain.Models.DTOs
{
    public class SsoDTO
    {
        public string Access_token { get; set; }
        public DateTime Expiration { get; set; }

        public SsoDTO(string access_token, DateTime expiration)
        {
            Access_token = access_token;
            Expiration = expiration;
        }
    }
}
