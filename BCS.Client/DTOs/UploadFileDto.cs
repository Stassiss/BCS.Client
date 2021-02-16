using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.DTOs
{
    public class UploadFileDto
    {
        public string ImageDataUri { get; set; }
        public string FileName { get; set; }
        public ImageDto Image { get; set; }
    }
}
