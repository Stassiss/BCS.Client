using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Client.DTOs;

namespace BCS.Client.Repository
{
    public interface IImageRepository
    {
        Task UploadImages(List<ImageDto> images, Guid projectId);
    }
}
