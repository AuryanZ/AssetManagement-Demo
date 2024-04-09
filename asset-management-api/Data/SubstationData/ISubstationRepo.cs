using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface ISubstationRepo
    {
        IEnumerable<ZoneSubstation> GetAllSubstations();
        ZoneSubstation GetSubstationById(int id);

        void CreateSubstation(ZoneSubstation substation);
        void UpdateSubstation(ZoneSubstation substation);

        bool SaveChanges();

        // void DeletSubstation(ZoneSubstation substation);
    }
}