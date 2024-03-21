using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/szone")]
    public class SubZoneController(ISzoneManageRepo szoneManageRepo,
    IMapper mapper) : ControllerBase
    {
        private readonly ISzoneManageRepo _szoneRepository = szoneManageRepo;
        private readonly IMapper _mapper = mapper;

        // GET api/szone
        [HttpGet]
        // [Authorize]
        public ActionResult<IEnumerable<SubZone>> GetAllSzone()
        {
            var szoneItems = _szoneRepository.GetAllSzone();
            return Ok(szoneItems);
        }

        [HttpGet("{id}", Name = "GetSzoneById")]
        // [Authorize]
        public ActionResult<ReadSubZoneDto> GetSzoneById(int id)
        {
            var szoneItem = _szoneRepository.GetSzoneById(id);
            if (szoneItem != null)
            {
                return Ok(_mapper.Map<ReadSubZoneDto>(szoneItem));
            }
            return NotFound();
        }

        [HttpGet("details/{id}")]
        // [Authorize]
        public ActionResult<SubZoneDetailDto> GetSzoneDetails(int id)
        {
            var szoneItem = _szoneRepository.GetSzoneById(id);
            IEnumerable<Asset> assets = _szoneRepository.GetAssetBySubZoneId(id);
            IEnumerable<AssetBySzonDto> assetBySzonDtos =
                _mapper.Map<IEnumerable<AssetBySzonDto>>(assets);

            if (szoneItem != null)
            {
                // szoneItem.Assets = assetBySzonDtos;
                // return Ok(_mapper.Map<SubZoneDetailDto>(szoneItem));
            }
            return NotFound();
        }

        [HttpPost("create-szone")]
        public ActionResult<SubZoneCreateDto> CreateSzone(SubZoneCreateDto szone)
        {
            Console.WriteLine(szone);
            var szoneModel = _mapper.Map<SubZone>(szone);
            _szoneRepository.CreateSzone(szoneModel);
            _szoneRepository.SaveChanges();

            return NoContent();
        }

    }

}