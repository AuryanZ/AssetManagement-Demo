using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/substation")]
    public class ZoneSubstationController(ISubstationRepo repository, IMapper mapper) : ControllerBase
    {
        private readonly ISubstationRepo _repository = repository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        // [Authorize]
        public ActionResult<IEnumerable<ZoneSubstation>> GetAllSubstations()
        {
            var substationItems = _repository.GetAllSubstations();
            return Ok(substationItems);
        }

        [HttpGet("{id}", Name = "GetSubstationById")]
        [Authorize]
        public ActionResult<ZoneSubstation> GetSubstationById(int id)
        {
            var substationItem = _repository.GetSubstationById(id);
            if (substationItem != null)
            {
                return Ok(substationItem);
            }
            return NotFound();
        }

        [HttpPost("create")]
        // [Authorize]
        public ActionResult<ZoneSubstation> CreateSubstation(SubstationCreateDto substationCreateDto)
        {
            var substationModel = _mapper.Map<ZoneSubstation>(substationCreateDto);
            _repository.CreateSubstation(substationModel);
            _repository.SaveChanges();

            return Ok();

        }

       
    }
    

}