using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading.Tasks;
using UploadFilePDF.Dtos.File;
using UploadFilePDF.Services;

namespace UploadFilePDF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _service;
        private readonly IWebHostEnvironment _enviroment;

        public FileController(IFileService service, IWebHostEnvironment environment)
        {
            _service = service;
            _enviroment = environment;
        }

        [HttpPost()]
        public async Task<IActionResult> SaveFile([Required] IFormFile fileDto)
        {
            try
            {
                ReadFile result = _service.SaveFileS3(fileDto, _enviroment.ContentRootPath);

                return Ok(new ApiResponse("File uploaded.", result, 201));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
