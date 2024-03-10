using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface IAssetManageRepo
    {
        IEnumerable<Asset> GetAllAssets();
        Asset GetAssetById(int id);

        void CreateAsset(Asset asset);

        bool SaveChanges();

        void UpdateAsset(Asset asset);
        void DeletAsset(Asset asset);
    }
}