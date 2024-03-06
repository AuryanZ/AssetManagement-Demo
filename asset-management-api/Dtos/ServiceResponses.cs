namespace AssetManagement.Dtos
{
    public class ServiceResponses
    {
        public record class GeneralServiceResponse(int status, string msg);
        public record class AccountServiceResponse(
                int status, string accessToken, string refreshToken, string msg);
    }
}