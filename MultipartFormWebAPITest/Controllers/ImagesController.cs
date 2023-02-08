using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultipartFormWebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        // GET: api/<ImagesController>
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(500);
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return StatusCode(500);
        }

        // POST api/<ImagesController>
        [HttpPost]
        public IActionResult Post([FromForm] IFormFileCollection files)
        {
            if (!Request.ContentType!.StartsWith("multipart/form-data") || files is null)
            {
                return new UnsupportedMediaTypeResult();
            }

            if (files.Count == 0)
            {
                return BadRequest();
            }

            using var readStream = files[0].OpenReadStream();

            var bytes = new byte[readStream.Length];

            readStream.Read(bytes);

            return File(bytes, files[0].ContentType);
        }

        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return StatusCode(500);
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(500);
        }
    }
}
