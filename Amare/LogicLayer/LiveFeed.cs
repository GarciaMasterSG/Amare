using Amare.Data;
using Amare.Models;
using Imagekit.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LiveFeed
    {
        private readonly ILiveFeed _LiveFeed;

        public LiveFeed(ILiveFeed liveFeed)
        {
            _LiveFeed = liveFeed;
        }

        public async Task<List<LiveFeedGetDTO>> GetLiveFeed(string weddingCode)
        {
            return await _LiveFeed.GetLiveFeed(weddingCode);
        }

        public async Task PostLiveFeed(LiveFeedPostDTO post, string description, string weddingCode, string userName)
        {
            byte[] finalPhoto;

            using (var ms = new MemoryStream())
            {
                await post.PhotoFeed.CopyToAsync(ms);
                finalPhoto = ms.ToArray();
            }

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(post.PhotoFeed.Name)}";

            FileCreateRequest request = new FileCreateRequest
            {
                fileName = fileName,
                file = finalPhoto
            };

            ImagekitClient client = new ImagekitClient(
                    "public_jZfFHjT6Nk4sgB7UV5t5AGEg94s=",
                    "private_qyNFMlBLnJDNFUIEAulCe8dZnhg=",
                    "https://ik.imagekit.io/Garcia5050"
            );

            var response = client.Upload(request);

            await _LiveFeed.PostLiveFeed(fileName, post.Description, weddingCode, userName);

        }
    }
}
