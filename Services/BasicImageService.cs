using CinematicSuite.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CinematicSuite.Services
{
    public class BasicImageService : IImageService
    {
        private readonly IHttpClientFactory _httpclient;

        public BasicImageService(IHttpClientFactory httpclient)
        {
            _httpclient = httpclient;
        }

        public string DecodeImage(byte[] poster, string contentType)
        {
            if (poster == null) return null;
            var posterImage = Convert.ToBase64String(poster);
            return $"data:{contentType};base74,{posterImage}";
        }

        public async Task<byte[]> EncodeImageAsync(IFormFile poster)
        {
            using var ms = new MemoryStream();
            if (poster == null) return null;
            await poster.CopyToAsync(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> EncodeImageURLAsync(string imageURL)
        {
            var client = _httpclient.CreateClient();
            var response = await client.GetAsync(imageURL);
            using Stream stream = await response.Content.ReadAsStreamAsync();

            var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}
