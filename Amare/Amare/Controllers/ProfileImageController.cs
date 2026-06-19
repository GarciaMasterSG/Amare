using Amare.Data;
using Imagekit.Sdk;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

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

            var profileImage = new ProfileImageDomain
            {
                Image = image,
                UserId = userId,
                FileName = Photo.FileName,
            };

            await _profileImage.PostProfileImage(profileImage);

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetProfileImage()
        {
            ProfileImageDomain Id = new ProfileImageDomain
            {
                UserId = HttpContext.Session.GetInt32("UserId"),
            };

            if (Id.UserId == null)
            {
                return BadRequest();
            }

            List<string> imageUrl = await _profileImage.GetProfileImage(Id);

            return Ok(new { ImageUrl = imageUrl.FirstOrDefault() });
        } 
    }
}
