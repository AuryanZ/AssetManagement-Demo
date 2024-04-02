using AssetManagement.Data;
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
            Console.WriteLine("Get Transfomers");
            var transformerItems = _repository.GetAllTransformers();
            Console.WriteLine(transformerItems);
            return Ok(transformerItems);
        }
    }

}