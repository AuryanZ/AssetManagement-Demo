using AssetManagement.Dtos;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface ITransformerRepo
    {
        IEnumerable<Transformer> GetAllTransformers();
        Transformer GetTransformerById(int id);

        void CreateTransformer(Transformer transformer);
        void UpdateTransformer(Transformer transformer);

        bool SaveChanges();

        // void DeletTransformer(Transformer transformer);
    }
}