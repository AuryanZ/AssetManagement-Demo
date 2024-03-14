using AssetManagement.Dtos;
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

        public void CreateAsset(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            _context.Assets.Add(asset);
        }

        public void DeletAsset(Asset asset)
        {
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }
            _context.Assets.Remove(asset);
        }

        public IEnumerable<Asset> GetAllAssets()
        {
            return _context.Assets.ToList();
        }

        public Asset GetAssetById(int id)
        {
            return _context.Assets.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Asset> GetAssetByPage(int page, int limit)
        {
            return _context.Assets.Skip((page - 1) * limit).Take(limit).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAsset(Asset asset)
        {
            // Nothing
        }

        public int GetTotalAssets()
        {
            return _context.Assets.Count();
        }

        public IEnumerable<Asset> GetAssetByConditionAndPage(int page, int limit, string condition)
        {
            if (condition == null)
            {
                return GetAssetByPage(page, limit);
            }
            return GetAssetByCondition(condition).Skip((page - 1) * limit).Take(limit).ToList();
        }

        private IEnumerable<Asset> GetAssetByCondition(string condition)
        {
            throw new NotImplementedException();
        }

        public int GetTotalAssetsByCondition(string condition)
        {
            throw new NotImplementedException();
        }

    }
}