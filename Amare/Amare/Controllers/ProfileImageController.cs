using Amare.Data;
using Imagekit.Sdk;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileImageController : BaseController
    {
        private readonly ProfileImage _profileImage;

        public ProfileImageController(ProfileImage profileImage)
        {
            _profileImage = profileImage;
        }

        [HttpPost]
        public async Task<IActionResult> PostProfileImage(IFormFile Photo)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            Stream image = Photo.OpenReadStream();

            await _profileImage.PostProfileImage(image, userId.Value, Photo.FileName);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetProfileImage()
        {
            int? userId = HttpContext?.Session?.GetInt32("UserId");

            if (userId == null)
            {
                return BadRequest();
            }

            List<string> imageUrl = await _profileImage.GetProfileImage(userId.Value);

            return Ok(new { ImageUrl = imageUrl.FirstOrDefault() });
        } 
    }
}
