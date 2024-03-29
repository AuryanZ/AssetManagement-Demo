using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface IAssetManageRepo
    {
        IEnumerable<Asset> GetAllAssets();
        IEnumerable<Asset> GetAssetByPage(int page, int limit, Asset[] asset = null);
        Asset[] GetAssetByCondition(string condition);
        Asset GetAssetById(int id);
        void CreateAsset(Asset asset);

        bool SaveChanges();

        void UpdateAsset(Asset asset);
        void DeletAsset(Asset asset);
        int GetTotalAssets();
        int GetTotalAssetsByCondition(string condition);
    }
}