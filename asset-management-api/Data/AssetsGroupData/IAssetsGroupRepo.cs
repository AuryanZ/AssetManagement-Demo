using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface IAssetGroupRepo
    {
        IEnumerable<AssetsGroup> GetAllGroup();
        AssetsGroup GetGroupById(int id);

        void CreateGroup(AssetsGroup substation);
        void CreateZoneSubstation(ZoneSubstation zoneSubstation);
        void UpdateGroup(AssetsGroup substation);

        bool SaveChanges();

        // void DeletSubstation(ZoneSubstation substation);
    }
}