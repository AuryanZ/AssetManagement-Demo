namespace AssetManagement.Dtos
{
    public record class AccountServiceResponse(int status, string accessToken, string refreshToken, string msg)
        : GeneralServiceResponse(status, msg);
}