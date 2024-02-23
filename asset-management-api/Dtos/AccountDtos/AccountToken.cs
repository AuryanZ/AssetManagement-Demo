namespace AssetManagement.Dtos
{
    public class AccountToken
    {
        public string AccessToken { get; set; }
        public int Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}