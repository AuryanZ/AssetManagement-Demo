namespace AssetManagement.Dtos
{
    public class AccountChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string accessToken { get; set; }
    }
}