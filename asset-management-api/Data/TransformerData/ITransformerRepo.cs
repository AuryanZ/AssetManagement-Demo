using AssetManagement.Dtos;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public interface ITransformerRepo
    {
        IEnumerable<GetTransformersDto> GetAllTransformers();
        Transformer GetTransformerById(int id);

        void CreateTransformer(Transformer transformer, Asset asset);

        bool SaveChanges();

        // void UpdateTransformer(Transformer transformer);
        // void DeletTransformer(Transformer transformer);
    }
}