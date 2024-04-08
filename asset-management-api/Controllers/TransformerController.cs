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

        [HttpGet("{id}", Name = "GetTransformerById")]
        [Authorize]
        public ActionResult<Transformer> GetTransformerById(int id)
        {
            var transformerItem = _repository.GetTransformerById(id);
            if (transformerItem != null)
            {
                return Ok(transformerItem);
            }
            return NotFound();
        }

        [HttpPost("new")]
        [Authorize]
        public ActionResult<GetTransformersDto> CreateTransformer(PostTransformersDto transformer)
        {
            //Get user name from token
            var userName = User.Identity.Name;
            try
            {
                var transformerModel = _mapper.Map<Transformer>(transformer);
                transformerModel.LastModifiedBy = userName;
                foreach (var pro in transformerModel.GetType().GetProperties())
                {
                    Console.WriteLine(pro.Name + " : " + pro.GetValue(transformerModel, null));
                }
                _repository.CreateTransformer(transformerModel);
                _repository.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        // [HttpPut("{id}")]
        // [Authorize]
        // public ActionResult UpdateTransformer(int id, PostTransformersDto transformer)
        // {
        //     var transformerModelFromRepo = _repository.GetTransformerById(id);
        //     if (transformerModelFromRepo == null)
        //     {
        //         return NotFound();
        //     }
        //     _mapper.Map(transformer, transformerModelFromRepo);
        //     // _repository.UpdateTransformer(transformerModelFromRepo);
        //     _repository.SaveChanges();
        //     return NoContent();
        // }

        [HttpPatch("updateItem={id}")]
        [Authorize]
        public ActionResult PartialTransformerUpdate(int id, JsonPatchDocument<PostTransformersDto> patchDoc)
        {
            var transformerModelFromRepo = _repository.GetTransformerById(id);
            if (transformerModelFromRepo == null)
            {
                return NotFound();
            }
            var transformerToPatch = _mapper.Map<PostTransformersDto>(transformerModelFromRepo);
            patchDoc.ApplyTo(transformerToPatch, ModelState);
            if (!TryValidateModel(transformerToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(transformerToPatch, transformerModelFromRepo);
            // _repository.UpdateTransformer(transformerModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpPatch("updateItems={ids}")]
        [Authorize]
        public ActionResult PartialTransformerUpdate(string ids, JsonPatchDocument<PostTransformersDto> patchDoc)
        {
            var idList = ids.Split('&').Select(Int32.Parse).ToList();
            var errorMsg = new List<string>();
            foreach (var id in idList)
            {
                var transformerModelFromRepo = _repository.GetTransformerById(id);
                if (transformerModelFromRepo == null)
                {
                    errorMsg.Add($"Transformer with id: {id} not found");
                    continue;
                }
                var transformerToPatch = _mapper.Map<PostTransformersDto>(transformerModelFromRepo);
                patchDoc.ApplyTo(transformerToPatch, ModelState);
                if (!TryValidateModel(transformerToPatch))
                {
                    errorMsg.Add($"Transformer with id: {id} failed validation {ModelState}");
                    // return ValidationProblem(ModelState);
                    continue;
                }
                _mapper.Map(transformerToPatch, transformerModelFromRepo);
                // // _repository.UpdateTransformer(transformerModelFromRepo);
                _repository.SaveChanges();
            }
            if (errorMsg.Count > 0)
            {
                return StatusCode(207, errorMsg);
            }
            return NoContent();
        }
    }

}