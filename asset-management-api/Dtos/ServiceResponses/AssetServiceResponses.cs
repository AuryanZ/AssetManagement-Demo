using AssetManagement.Models;

namespace AssetManagement.Dtos
{
    public record class AssetServiceResponse(int status, string msg, int count, IEnumerable<Asset> assets)
        : GeneralServiceResponse(status, msg);

    public record class AssetsSearchServiceResponse(int status, string msg, int count, AssetReadDto[] assets)
        : GeneralServiceResponse(status, msg);

}