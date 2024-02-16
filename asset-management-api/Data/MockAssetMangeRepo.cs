// using AssetManagement.Models;

// namespace AssetManagement.Data
// {
//     public class MockAssetMangeRepo : IAssetManageRepo
//     {
//         public void CreateAsset(AssetManage asset)
//         {
//             throw new NotImplementedException();
//         }

//         public IEnumerable<AssetManage> GetAllAssets()
//         {
//             var assets = new List<AssetManage>{
//                 new AssetManage
//                 {
//                     Id = 0,
//                     AssetName = "Asset 1",
//                     AssetType = "Type 1",
//                     AssetDescription = "Description 1",
//                     AssetLocation = "Location 1",
//                     AssetStatus = "In Service"
//                 },
//                 new AssetManage
//                 {
//                     Id = 1,
//                     AssetName = "Asset 2",
//                     AssetType = "Type 2",
//                     AssetDescription = "Description 2",
//                     AssetLocation = "Location 2",
//                     AssetStatus = "In Service"
//                 },
//                 new AssetManage
//                 {
//                     Id = 2,
//                     AssetName = "Asset 3",
//                     AssetType = "Type 3",
//                     AssetDescription = "Description 3",
//                     AssetLocation = "Location 3",
//                     AssetStatus = "In Service"
//                 }
//             };

//             return assets;
//         }

//         public AssetManage GetAssetById(int id)
//         {
//             return new AssetManage
//             {
//                 Id = 0,
//                 AssetName = "Asset 1",
//                 AssetType = "Type 1",
//                 AssetDescription = "Description 1",
//                 AssetLocation = "Location 1",
//                 AssetStatus = "In Service"
//             };
//         }

//         public bool SaveChanges()
//         {
//             throw new NotImplementedException();
//         }

//         public void UpdateAsset(AssetManage asset)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }