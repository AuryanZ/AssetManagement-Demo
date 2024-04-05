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
            Console.WriteLine("Get all Transformers");
            var transformerItems = _repository.GetAllTransformers();
            return Ok(transformerItems);
        }

        [HttpPost("new")]
        // [Authorize]
        public ActionResult<GetTransformersDto> CreateTransformer(PostTransformersDto transformer)
        {
            try
            {
                var transformerModel = _mapper.Map<Transformer>(transformer);
                foreach (var pro in transformerModel.GetType().GetProperties())
                {
                    Console.WriteLine(pro.Name + " : " + pro.GetValue(transformerModel, null));
                }
                _repository.CreateTransformer(transformerModel);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("+++++++++++++++++++++++++++++", e);
            }
            return NoContent();
        }
    }

}