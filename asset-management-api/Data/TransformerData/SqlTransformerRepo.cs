using AssetManagement.Dtos;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlTransformerRepo(AssetContext context) : ITransformerRepo
    {
        private AssetContext _context = context;

        public void CreateTransformer(Transformer transformer, Asset asset)
        {
            if (transformer == null)
            {
                throw new ArgumentNullException(nameof(transformer));
            }
            if (asset == null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            if (asset.CommissionedDate == DateTime.MinValue)
            {
                asset.CommissionedDate = DateTime.Now;
            }
            asset.CreatDate = DateTime.Today;
            asset.LastModifiedDate = DateTime.Today;
            Console.WriteLine("TOday "+ DateTime.Today);
            // Console.WriteLine("transforer "+ transformer);
            // Console.WriteLine("Asset "+asset);
            try
            {
                // check if the asset exist
                if (_context.Assets.FirstOrDefault(p => p.AssetId == asset.AssetId) == null
                || string.IsNullOrEmpty(asset.AssetId.ToString()))
                {
                    // Console.WriteLine("Adding new asset", asset);
                    _context.Assets.Add(asset);
                    // save new asset id to transformer
                    Console.WriteLine("Asset ID "+asset.AssetId);
                    transformer.AssetID = asset.AssetId;
                }

                _context.Transformer.Add(transformer);
                Console.WriteLine("Transformer added");
            }
            catch(Exception e){
                Console.WriteLine(e);
            }

        }

        public IEnumerable<GetTransformersDto> GetAllTransformers()
        {
            //select data from Transformer left join Asset on Transformer.AssetID = Asset.AssetID
            try
            {
                var Query = from transformer in _context.Transformer
                            join asset in _context.Assets on transformer.AssetID equals asset.AssetId
                            select new GetTransformersDto
                            {
                                Name = transformer.TransformerName,
                                SerialNumber = transformer.SerialNumber,
                                Manufacturer = transformer.Manufacturer,
                                GPS = transformer.GPS,
                                IO = transformer.InputVotage + " / " + transformer.OutputVotage,
                                LandOwner = transformer.LandOwner,
                                AssetId = asset.AssetId,
                                LocalId = asset.AssetLocalID,
                                AssetOwner = asset.AssetOwner,
                                Status = asset.Status,
                                GXP = asset.GXP,
                                Feeder = asset.Feeder,
                                Location = asset.Location,
                                Note = asset.Note
                            };
                return Query.ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public Transformer GetTransformerById(int id)
        {
            return _context.Transformer.FirstOrDefault(p => p.TransformerId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}