using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlSzoneManagerRepo(AssetContext context) : ISzoneManageRepo
    {
        private AssetContext _context = context;

        public IEnumerable<SubZone> GetAllSzone()
        {
            return _context.SubZone.ToList();
        }

        public SubZone GetSzoneById(int id)
        {
            return _context.SubZone.FirstOrDefault(p => p.Id == id);
        }

        public void CreateSzone(SubZone szone)
        {
            if (szone == null)
            {
                throw new ArgumentNullException(nameof(szone));
            }
            _context.SubZone.Add(szone);
        }

        // public void DeletSzone(SubZone szone)
        // {
        //     throw new NotImplementedException();
        // }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Asset> GetAssetBySubZoneId(int id)
        {
            IEnumerable<Asset> assets = _context.Assets.
                Where(p => p.SubZoneID == id).ToList();

            return assets;
        }

        // public void UpdateSzone(SubZone szone)
        // {
        //     throw new NotImplementedException();
        // }
    }
}