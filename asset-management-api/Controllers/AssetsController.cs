using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetsController(IAssetManageRepo repository, IMapper mapper) : ControllerBase
    {
        private readonly IAssetManageRepo _repository = repository;
        private readonly IMapper _mapper = mapper;

        // GET api/assets
        [HttpGet]
        [Authorize(Roles = "admin, user")]
        public ActionResult<IEnumerable<Asset>> GetAllAssets()
        {
            var assetItems = _repository.GetAllAssets();
            return Ok(assetItems);
        }

        //GET api/assets/{id}
        [HttpGet("{id}", Name = "GetAssetById")]
        [Authorize(Roles = "admin, user")]
        public ActionResult<AssetReadDto> GetAssetById(int id)
        {
            var assetItem = _repository.GetAssetById(id);
            if (assetItem != null)
            {
                return Ok(_mapper.Map<AssetReadDto>(assetItem));
            }
            return NotFound();
        }

        //Get api/assets/{page}/{limit}
        [HttpGet("{page}/{limit}", Name = "GetAssetByPage")]
        [Authorize(Roles = "admin, user")]
        public ActionResult<AssetsSearchServiceResponse> GetAssetByPage(int page, int limit)
        {
            var assetItems = _repository.GetAssetByPage(page, limit);
            var test = _mapper.Map<AssetReadDto[]>(assetItems);

            var count = _repository.GetTotalAssets();
            if (assetItems != null)
            {
                return Ok(new AssetsSearchServiceResponse(200, "Success", count, test));
            }
            return NotFound();
        }

        //Get Asset by conditon and page api/assets/{condition}/{page}/{limit}
        [HttpGet("{condition}/{page}/{limit}", Name = "GetAssetByConditionAndPage")]
        [Authorize(Roles = "admin, user")]
        public ActionResult<AssetServiceResponse> GetAssetByConditionAndPage(string condition, int page, int limit)
        {
            var assetByCondtion = _repository.GetAssetByCondition(condition);
            var assetItems = _repository.GetAssetByPage(page, limit, assetByCondtion);
            var count = assetByCondtion.Count();
            if (assetItems != null)
            {
                return Ok(new AssetServiceResponse(200, "Success", count, assetItems));
            }
            return NotFound();
        }

        // POST batch asset api/assets/batch
        [HttpPost("create-assets")]
        public ActionResult<AssetReadDto> CreateMultiAsset(AssetCreateDto[] assetCreateDto)
        {
            foreach (var asset in assetCreateDto)
            {
                var assetModel = _mapper.Map<Asset>(asset);
                _repository.CreateAsset(assetModel);
            }
            _repository.SaveChanges();

            return NoContent();
        }


        // PUT api/assets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAsset(int id, AssetUpdateDto assetUpdateDto)
        {
            var assetModelFromRepo = _repository.GetAssetById(id);
            if (assetModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(assetUpdateDto, assetModelFromRepo);

            _repository.UpdateAsset(assetModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/assets/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialAssetUpdate(int id, JsonPatchDocument<AssetUpdateDto> patchDoc)
        {
            var assetModelFromRepo = _repository.GetAssetById(id);
            if (assetModelFromRepo == null)
            {
                return NotFound();
            }

            var assetToPatch = _mapper.Map<AssetUpdateDto>(assetModelFromRepo);
            patchDoc.ApplyTo(assetToPatch, ModelState);

            if (!TryValidateModel(assetToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(assetToPatch, assetModelFromRepo);

            _repository.UpdateAsset(assetModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH batch asset by ids api/assets/batch/[ids]
        [HttpPatch("batch/{ids}")]
        public ActionResult PartialAssetUpdate(string ids, JsonPatchDocument<AssetUpdateDto> patchDoc)
        {
            // split ids by & and convert to array of int
            string[] _ids = ids.ToString().Split('&');

            foreach (var id in _ids)
            {
                //chagne id to int
                int.TryParse(id, out int _id);

                var assetModelFromRepo = _repository.GetAssetById(_id);
                if (assetModelFromRepo == null)
                {
                    return NotFound();
                }

                var assetToPatch = _mapper.Map<AssetUpdateDto>(assetModelFromRepo);
                patchDoc.ApplyTo(assetToPatch, ModelState);

                if (!TryValidateModel(assetToPatch))
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(assetToPatch, assetModelFromRepo);

                _repository.UpdateAsset(assetModelFromRepo);
            }

            _repository.SaveChanges();

            return NoContent();
        }


        // Delet api/assets/{id}
        [HttpDelete("{ids}")]
        public ActionResult DeleteAsset(String ids)
        {
            try
            {
                string[] _ids = ids.ToString().Split('&');
                foreach (var id in _ids)
                {
                    int.TryParse(id, out int _id);
                    var assetModelFromRepo = _repository.GetAssetById(_id);
                    if (assetModelFromRepo == null)
                    {
                        return NotFound();
                    }

                    _repository.DeletAsset(assetModelFromRepo);
                    _repository.SaveChanges();
                }
            }
            catch
            {
                int.TryParse(ids, out int _id);
                var assetModelFromRepo = _repository.GetAssetById(_id);
                if (assetModelFromRepo == null)
                {
                    return NotFound();
                }

                _repository.DeletAsset(assetModelFromRepo);
                _repository.SaveChanges();
            }

            return NoContent();
        }
    }
}