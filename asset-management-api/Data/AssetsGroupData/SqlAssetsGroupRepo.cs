using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlAssetsGroupRepo(AssetContext context) : IAssetGroupRepo
    {
        private AssetContext _context = context;


        public IEnumerable<AssetsGroup> GetAllGroup()
        {
            return _context.AssetsGroups.ToList();
            // return null;
        }

        public AssetsGroup GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateGroup(AssetsGroup assetsGroup)
        {
            //
        }
        public void CreateGroup(AssetsGroup assetsGroup)
        {
            if (assetsGroup == null)
            {
                throw new ArgumentNullException(nameof(assetsGroup));
            }
            _context.AssetsGroups.Add(assetsGroup);
        }

        public void CreateZoneSubstation(ZoneSubstation zoneSubstation)
        {
            if (zoneSubstation == null)
            {
                throw new ArgumentNullException(nameof(zoneSubstation));
            }
            _context.ZoneSubstations.Add(zoneSubstation);
        }
    }
}