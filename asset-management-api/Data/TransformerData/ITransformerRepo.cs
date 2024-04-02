using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface ITransformerRepo
    {
        IEnumerable<Transformer> GetAllTransformers();
        Transformer GetTransformerById(int id);

        void CreateTransformer(Transformer transformer);

        bool SaveChanges();

        // void UpdateTransformer(Transformer transformer);
        // void DeletTransformer(Transformer transformer);
    }
}