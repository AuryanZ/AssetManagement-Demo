using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class SqlTransformerRepo(AssetContext context) : ITransformerRepo
    {
        private AssetContext _context = context;

        public void CreateTransformer(Transformer transformer)
        {

            // foreach (var pro in transformer.AssetsGroup.GetType().GetProperties())
            // {
            //     Console.WriteLine(pro.Name + " : " + pro.GetValue(transformer.AssetsGroup, null));
            // }
            if (transformer == null)
            {
                throw new ArgumentNullException(nameof(transformer));
            }
            
            if (transformer.AssetsGroup != null)
            {
                transformer.AssetsGroup = _context.AssetsGroups.FirstOrDefault(p => p.GroupId == transformer.AssetsGroup.GroupId);
            }
            // transformer.AssetsGroup = _context.AssetsGroups.FirstOrDefault(p => p.GroupId == transformer.AssetsGroup.GroupId);
            _context.Assets.Add(transformer);


        }

        public IEnumerable<Transformer> GetAllTransformers()
        {
            // var transformers = _context.Assets.OfType<Transformer>();
            var Query = from transformers in _context.Assets.OfType<Transformer>()
                        join AssetsGroup in _context.AssetsGroups on transformers.AssetsGroup.GroupId
                        equals AssetsGroup.GroupId into transformerAssetsGroup
                        from AssetsGroup in transformerAssetsGroup.DefaultIfEmpty()
                        select new Transformer(transformers.AssetLocalID, transformers.Category,
                                                transformers.Status, transformers.Gxp, transformers.Feeder,
                                                transformers.Location, transformers.Note, transformers.AssetOwner,
                                                transformers.LastModifiedBy, transformers.CommissionedDate)
                        {
                            AssetId = transformers.AssetId,
                            AssetLocalID = transformers.AssetLocalID,
                            Category = transformers.Category,
                            Status = transformers.Status,
                            Gxp = transformers.Gxp,
                            Feeder = transformers.Feeder,
                            Location = transformers.Location,
                            Note = transformers.Note,
                            AssetOwner = transformers.AssetOwner,
                            CreatDate = transformers.CreatDate,
                            CommissionedDate = transformers.CommissionedDate,
                            LastModifiedDate = transformers.LastModifiedDate,
                            LastModifiedBy = transformers.LastModifiedBy,
                            // ZoneSubstationId = transformers.ZoneSubstationId,
                            // ZoneSubstation = ZoneSubstation,
                            AssetsGroup = AssetsGroup,
                            TransformerName = transformers.TransformerName,
                            SerialNumber = transformers.SerialNumber,
                            GPS = transformers.GPS,
                            Address = transformers.Address,
                            InputVotage = transformers.InputVotage,
                            OutputVotage = transformers.OutputVotage,
                            LandOwner = transformers.LandOwner,
                            Manufacturer = transformers.Manufacturer,
                            RegLife = transformers.RegLife,
                            Description = transformers.Description,
                            DisposalDate = transformers.DisposalDate,
                            DisposalReason = transformers.DisposalReason
                        };
            return Query.ToList();
        }

        public Transformer GetTransformerById(int id)
        {
            var Query = from transformers in _context.Assets.OfType<Transformer>()
                        where transformers.AssetId == id
                        join AssetsGroup in _context.AssetsGroups on transformers.AssetsGroup.GroupId
                        equals AssetsGroup.GroupId into transformerAssetsGroup
                        from AssetsGroup in transformerAssetsGroup.DefaultIfEmpty()
                        select new Transformer(transformers.AssetLocalID, transformers.Category,
                                                transformers.Status, transformers.Gxp, transformers.Feeder,
                                                transformers.Location, transformers.Note, transformers.AssetOwner,
                                                transformers.LastModifiedBy, transformers.CommissionedDate)
                        {
                            AssetId = transformers.AssetId,
                            AssetLocalID = transformers.AssetLocalID,
                            Category = transformers.Category,
                            Status = transformers.Status,
                            Gxp = transformers.Gxp,
                            Feeder = transformers.Feeder,
                            Location = transformers.Location,
                            Note = transformers.Note,
                            AssetOwner = transformers.AssetOwner,
                            CreatDate = transformers.CreatDate,
                            CommissionedDate = transformers.CommissionedDate,
                            LastModifiedDate = transformers.LastModifiedDate,
                            LastModifiedBy = transformers.LastModifiedBy,
                            // ZoneSubstationId = transformers.ZoneSubstationId,
                            // ZoneSubstation = ZoneSubstation,
                            AssetsGroup = AssetsGroup,
                            TransformerName = transformers.TransformerName,
                            SerialNumber = transformers.SerialNumber,
                            GPS = transformers.GPS,
                            Address = transformers.Address,
                            InputVotage = transformers.InputVotage,
                            OutputVotage = transformers.OutputVotage,
                            LandOwner = transformers.LandOwner,
                            Manufacturer = transformers.Manufacturer,
                            RegLife = transformers.RegLife,
                            Description = transformers.Description,
                            DisposalDate = transformers.DisposalDate,
                            DisposalReason = transformers.DisposalReason
                        };
            return Query.FirstOrDefault();
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