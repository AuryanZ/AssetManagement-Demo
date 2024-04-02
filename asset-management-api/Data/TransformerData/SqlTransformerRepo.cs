using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlTransformerRepo(AssetContext context) : ITransformerRepo
    {
        private AssetContext _context = context;

        public void CreateTransformer(Transformer transformer)
        {
            if (transformer == null)
            {
                throw new ArgumentNullException(nameof(transformer));
            }

            _context.Transformer.Add(transformer);
        }

        public IEnumerable<Transformer> GetAllTransformers()
        {
            return _context.Transformer.ToList();
        }

        public Transformer GetTransformerById(int id)
        {
            return _context.Transformer.FirstOrDefault(p => p.TransformerId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        IEnumerable<Transformer> ITransformerRepo.GetAllTransformers()
        {
            Console.WriteLine("TransformerRepo GetAllTransformers", _context.Transformer.ToList());
            return _context.Transformer.ToList();
        }

        Transformer ITransformerRepo.GetTransformerById(int id)
        {
            throw new NotImplementedException();
        }
    }
}