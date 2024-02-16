using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [Route("api/assets")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetManageRepo _repository;
        private readonly IMapper _mapper;

        public AssetsController(IAssetManageRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/assets
        [HttpGet]
        public ActionResult<IEnumerable<AssetManage>> GetAllAssets()
        {
            var assetItems = _repository.GetAllAssets();
            return Ok(assetItems);
        }

        //GET api/assets/{id}
        [HttpGet("{id}", Name = "GetAssetById")]
        public ActionResult<AssetReadDto> GetAssetById(int id)
        {
            var assetItem = _repository.GetAssetById(id);
            if (assetItem != null)
            {
                return Ok(_mapper.Map<AssetReadDto>(assetItem));
            }
            return NotFound();
        }

        // POST api/assets
        [HttpPost]
        public ActionResult<AssetReadDto> CreateAsset(AssetCreateDto assetCreateDto)
        {
            var assetModel = _mapper.Map<AssetManage>(assetCreateDto);
            _repository.CreateAsset(assetModel);
            _repository.SaveChanges();

            var assetReadDto = _mapper.Map<AssetReadDto>(assetModel);

            return CreatedAtRoute(nameof(GetAssetById), new { id = assetReadDto.Id }, assetReadDto);
        }

        // POST batch asset api/assets/batch
        [HttpPost("batch")]
        public ActionResult<AssetReadDto> CreateMultiAsset(AssetCreateDto[] assetCreateDto)
        {
            foreach (var asset in assetCreateDto)
            {
                var assetModel = _mapper.Map<AssetManage>(asset);
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
        public ActionResult PartialAssetUpdate(String ids, JsonPatchDocument<AssetUpdateDto> patchDoc)
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