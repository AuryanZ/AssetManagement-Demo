using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface IAssetManageRepo
    {
        IEnumerable<AssetManage> GetAllAssets();
        AssetManage GetAssetById(int id);

        void CreateAsset(AssetManage asset);

        bool SaveChanges();

        void UpdateAsset(AssetManage asset);
        void DeletAsset(AssetManage asset);
    }
}