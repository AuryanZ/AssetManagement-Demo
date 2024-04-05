using AssetManagement.Dtos;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlTransformerRepo(AssetContext context) : ITransformerRepo
    {
        private AssetContext _context = context;

        public void CreateTransformer(Transformer transformer)
        {

            foreach (var pro in transformer.GetType().GetProperties())
            {
                Console.WriteLine(pro.Name + " : " + pro.GetValue(transformer, null));
            }
            if (transformer == null)
            {
                throw new ArgumentNullException(nameof(transformer));
            }
            // _context.Transformer.Add(transformer);
            _context.Assets.Add(transformer);


        }

        public IEnumerable<Transformer> GetAllTransformers()
        {
            return _context.Assets.OfType<Transformer>().ToList();
        }

        public Transformer GetTransformerById(int id)
        {
            // return _context.Transformer.FirstOrDefault(p => p.TransformerId == id);
            return null;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}