using GymManagementApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly string _imageDirectory =
        Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "Images");

        [HttpPost("upload")]
        public IActionResult UploadImage(IFormFile imageFile)
        {
            string savedPath = ImageHelper.SaveImageToFile(imageFile, _imageDirectory);
            if (string.IsNullOrEmpty(savedPath))
                return BadRequest("Failed to upload image.");

            return Ok(new { Path = savedPath });
        }
        [HttpGet("get/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            string filePath = Path.Combine(_imageDirectory, fileName);
            byte[] imageData = ImageHelper.ReadFileBytes(filePath);

            if (imageData == null)
                return NotFound("Image not found.");

            string base64String = Convert.ToBase64String(imageData);
            return Ok(new { Base64Image = $"data:image/jpeg;base64,{base64String}" });
        }
    }
}
