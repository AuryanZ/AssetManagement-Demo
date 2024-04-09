using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlSubstationRepo(AssetContext context) : ISubstationRepo
    {
        private AssetContext _context = context;


        public IEnumerable<ZoneSubstation> GetAllSubstations()
        {
            return _context.ZoneSubstations.ToList();
        }

        public ZoneSubstation GetSubstationById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateSubstation(ZoneSubstation substation)
        {
            //
        }
        public void CreateSubstation(ZoneSubstation substation)
        {
            if (substation == null)
            {
                throw new ArgumentNullException(nameof(substation));
            }
            _context.ZoneSubstations.Add(substation);
        }
    }
}