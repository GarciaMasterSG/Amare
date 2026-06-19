using Amare.Data;
using Imagekit.Sdk;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ProfileImage
    {
        private readonly IProfileImage _profileImage;

        public ProfileImage(IProfileImage profileImage)
        {
            _profileImage = profileImage;
        }

        public async Task PostProfileImage(ProfileImageDomain image)
        {
            byte[] PhotoImage;

            using (var ms = new MemoryStream())
            {
                await image.Image.CopyToAsync(ms);
                PhotoImage = ms.ToArray();
            }

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";

            FileCreateRequest request = new FileCreateRequest
            {
                file = PhotoImage,
                fileName = fileName
            };

            ImagekitClient client = new ImagekitClient(
                "public_jZfFHjT6Nk4sgB7UV5t5AGEg94s=",
                "private_qyNFMlBLnJDNFUIEAulCe8dZnhg=",
                "https://ik.imagekit.io/Garcia5050"
            );

            var upload = client.Upload(request);

            var postImage = new ProfileImageDomain
            {
                FileName = fileName,
                UserId = image.UserId,
            };

            await _profileImage.PostProfileImage(postImage); 
        }

        public async Task<List<string>> GetProfileImage(ProfileImageDomain userId)
        {
            var imageUrl = await _profileImage.GetProfileImage(userId);

            return imageUrl;
        }
    }
}
