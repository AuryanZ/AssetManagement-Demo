using AssetManagement.Data;
using AssetManagement.Dtos;
using AssetManagement.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/transformers")]
    public class TransformerController(ITransformerRepo repository, IMapper mapper) : ControllerBase
    {
        private readonly ITransformerRepo _repository = repository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        // [Authorize]
        public ActionResult<IEnumerable<Transformer>> GetAllTransformers()
        {
            var transformerItems = _repository.GetAllTransformers();
            return Ok(transformerItems);
        }

        [HttpPost("new-Transformers")]
        // [Authorize]
        public ActionResult<GetTransformersDto> CreateTransformer(PostTransformersDto transformer)
        {
            //Get user name from header
            // var userName = User.Identity.Name;
            // Console.WriteLine(userName);
            // transformer.LastModifiedBy = userName;
            transformer.LastModifiedBy = "userName";
            
            var transformerData = _mapper.Map<Transformer>(transformer);
            var AssetData = _mapper.Map<Asset>(transformer);
            // Console.WriteLine("Tx Data ", transformerData);
            // Console.WriteLine("Assets Data " , AssetData);

            _repository.CreateTransformer(transformerData, AssetData);
            _repository.SaveChanges();
            return NoContent();

        }
    }

}