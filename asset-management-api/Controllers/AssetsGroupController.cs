using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/assetsGroup")]
    public class ZoneSubstationController(IAssetGroupRepo repository, IMapper mapper) : ControllerBase
    {
        private readonly IAssetGroupRepo _repository = repository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        // [Authorize]
        public ActionResult<IEnumerable<AssetsGroup>> GetAllGroup()
        {
            var substationItems = _repository.GetAllGroup();
            return Ok(substationItems);
        }

        [HttpGet("{id}", Name = "GetGroupById")]
        [Authorize]
        public ActionResult<AssetsGroup> GetGroupById(int id)
        {
            var substationItem = _repository.GetGroupById(id);
            if (substationItem != null)
            {
                return Ok(substationItem);
            }
            return NotFound();
        }

        [HttpPost("create")]
        // [Authorize]
        public ActionResult<AssetsGroup> CreateGroup(CreateAssetGroupDtos createAssetGroupDtos)
        {
            if (createAssetGroupDtos == null)
            {
                return BadRequest();
            }
            if (createAssetGroupDtos.GroupCategory.ToLower() == "substation")
            {
                var substationModel = _mapper.Map<ZoneSubstation>(createAssetGroupDtos);
                _repository.CreateZoneSubstation(substationModel);
                _repository.SaveChanges();

                return Ok();
            }
            else
            {
                var assetsGroupModel = _mapper.Map<AssetsGroup>(createAssetGroupDtos);
                _repository.CreateGroup(assetsGroupModel);
                _repository.SaveChanges();

                return Ok();
            }

        }

        [HttpPost("bulkCreate")]
        // [Authorize]
        public ActionResult<ZoneSubstation> BulkCreateGroup(CreateAssetGroupDtos[] createAssetGroupDtos)
        {
            foreach (var assetGroup in createAssetGroupDtos)
            {
                if (assetGroup.GroupCategory.ToLower() == "substation")
                {
                    var substationModel = _mapper.Map<ZoneSubstation>(assetGroup);
                    _repository.CreateZoneSubstation(substationModel);
                }
                else
                {
                    var assetsGroupModel = _mapper.Map<AssetsGroup>(assetGroup);
                    _repository.CreateGroup(assetsGroupModel);
                }
            }
            _repository.SaveChanges();

            return Ok();

        }


    }


}