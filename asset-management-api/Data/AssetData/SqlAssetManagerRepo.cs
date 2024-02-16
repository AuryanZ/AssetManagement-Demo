using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlAssetManagerRepo : IAssetManageRepo
    {
        private AssetContext _context;

        public SqlAssetManagerRepo(AssetContext context)
        {
            _context = context;
        }

        public void CreateAsset(AssetManage asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            _context.Assets.Add(asset);
        }

        public void DeletAsset(AssetManage asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }
            _context.Assets.Remove(asset);
        }

        public IEnumerable<AssetManage> GetAllAssets()
        {
            return _context.Assets.ToList();
        }

        public AssetManage GetAssetById(int id)
        {
            return _context.Assets.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAsset(AssetManage asset)
        {
            // Nothing
        }
    }
}