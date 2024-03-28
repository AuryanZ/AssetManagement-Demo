using AssetManagement.Dtos;
using AssetManagement.Models;
using Microsoft.Extensions.ObjectPool;

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
            return _context.Assets.FirstOrDefault(assets => assets.AssetId == id);
            // return null;
        }

        public IEnumerable<Asset> GetAssetByPage(int page, int limit, Asset[] asset = null)
        {
            if (asset == null)
            {
                return _context.Assets.Skip((page - 1) * limit).Take(limit).ToList();
            }

            return asset.Skip((page - 1) * limit).Take(limit).ToList();
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

        public Asset[] GetAssetByCondition(string condition)
        {
            if (condition == null)
            {
                return null;
            }

            condition = condition.Replace("\"", "");
            var conditionArray = new Dictionary<string, string>();
            var conditionList = condition.Split('&');
            foreach (var item in conditionList)
            {
                var keyValue = item.Split('=');
                conditionArray.Add(keyValue[0], keyValue[1]);
            }
            var query = _context.Assets.AsQueryable();
            foreach (var item in conditionArray)
            {
                Console.WriteLine(item.Key + " " + item.Value);
                if (item.Key == "location" && item.Value != "")
                {
                    // query = query.Where(p => p.Location == item.Value);
                }
                else if (item.Key == "status" && item.Value != "")
                {
                    query = query.Where(assets => assets.Status == item.Value);
                }
                else if (item.Key == "name" && item.Value != "")
                {
                    query = query.Where(p => p.Category == item.Value);
                }
            }

            return query.ToArray();

        }

        public int GetTotalAssetsByCondition(string condition)
        {
            throw new NotImplementedException();
        }

    }
}