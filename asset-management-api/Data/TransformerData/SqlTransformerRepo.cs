using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlTransformerRepo(AssetContext context) : ITransformerRepo
    {
        private AssetContext _context = context;

        public void CreateTransformer(Transformer transformer)
        {

            // foreach (var pro in transformer.GetType().GetProperties())
            // {
            //     Console.WriteLine(pro.Name + " : " + pro.GetValue(transformer, null));
            // }
            if (transformer == null)
            {
                throw new ArgumentNullException(nameof(transformer));
            }
            _context.Assets.Add(transformer);


        }

        public IEnumerable<Transformer> GetAllTransformers()
        {
            var transformers = _context.Assets.OfType<Transformer>().ToList();
            foreach (var trans in transformers)
            {
                if (trans.ZoneSubstationId != 0)
                {
                    //Get zonesub by id
                    trans.ZoneSubstation = _context.ZoneSubstations.FirstOrDefault(p => p.ZoneSubstationId == trans.ZoneSubstationId);
                }
            }
            return transformers;
        }

        public Transformer GetTransformerById(int id)
        {
            return _context.Assets.OfType<Transformer>().FirstOrDefault(p => p.AssetId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTransformer(Transformer transformer)
        {
            //Nothing
        }
    }
}