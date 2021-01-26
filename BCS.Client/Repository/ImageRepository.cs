using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BCS.Client.DTOs;
using BCS.Client.Helpers;

namespace BCS.Client.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly IHttpService _httpService;

        public ImageRepository(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task UploadImages(List<ImageDto> images, Guid projectId)
        {
            foreach (var image in images)
            {
                await _httpService.Post<ImageDto>($"projects/{projectId}/images", image);
            }
        }
    }
}
