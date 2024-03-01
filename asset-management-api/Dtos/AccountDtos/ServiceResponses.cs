namespace AssetManagement.Dtos
{
    public class ServiceResponses
    {
        public record class GeneralServiceResponse(bool Success, string Message);
        public record class AccountServiceResponse(
                bool Success, string accessToken, string refreshToken, string Message);
    }
}