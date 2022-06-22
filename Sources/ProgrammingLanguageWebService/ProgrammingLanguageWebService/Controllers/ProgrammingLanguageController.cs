using Microsoft.AspNetCore.Mvc;
using ProgrammingLanguageWebService.Models;
using ProgrammingLanguageWebService.Services;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingLanguageWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgrammingLanguageController : ControllerBase
    {
        #region Fields
        private readonly IFileService _fileService;
        #endregion

        #region Ctor
        public ProgrammingLanguageController(IFileService fileService)
        {
            _fileService = fileService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public ActionResult<IEnumerable<ProgrammingLanguageModel>> Get()
        {
            var programmingLanguageModels = _fileService.GetAll();
            if (programmingLanguageModels.Any())
            {
                return programmingLanguageModels;
            }
            else
            {
                return BadRequest("Not found!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProgrammingLanguageModel> Get(int id)
        {
            ProgrammingLanguageModel programmingLanguageModel = _fileService.GetById(id);
            if (programmingLanguageModel != null)
            {
                return programmingLanguageModel;
            }
            else
            {
                return StatusCode(404, "Not found!");
            }
        }

        [HttpPost]
        public void Post([FromBody] ProgrammingLanguageModel programmingLanguageModel)
        {
            _fileService.AddItem(programmingLanguageModel);
        }

        [HttpPut]
        public void Put([FromBody] ProgrammingLanguageModel programmingLanguageModel)
        {
            _fileService.UpdateItem(programmingLanguageModel);
        }

        [HttpDelete]
        public void Delete([FromBody] ProgrammingLanguageModel[] programmingLanguageModels)
        {
            foreach (ProgrammingLanguageModel programmingLanguageModel in programmingLanguageModels)
            {
                _fileService.DeleteItem(programmingLanguageModel);
            }
        }
        #endregion
    }
}