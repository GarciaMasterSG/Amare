using Amare.Data;
using Amare.Models;
using Imagekit;
using Imagekit.Sdk;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Amare.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiveFeedController : BaseController
    {
        private readonly LiveFeed _liveFeed;

        public LiveFeedController(LiveFeed liveFeed)
        {
            _liveFeed = liveFeed;
        }

        [HttpGet]
        public async Task<List<LiveFeedGetDTO>> LiveFeedGet()
        {
            var posts = await _liveFeed.GetLiveFeed(weddingnCode);  

            return posts;
        }

        [HttpPost]
        public async Task<IActionResult> PostLiveFeed([FromForm] LiveFeedPostDTO post)
        {
            if (post.Description.Length > 301)
            {
                return BadRequest(new { error = "Description cannot exceed 300 characters." });
            }

            if (post.PhotoFeed == null)
            {
                return BadRequest(new { error = "PhotoFeed is required." });
            }

            string userName = HttpContext.Session.GetString("UserName");

            await _liveFeed.PostLiveFeed(post, weddingnCode, userName);

            return Ok();
        }
    }
}
