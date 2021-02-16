using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.DTOs
{
    public class ImageDto
    {
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public bool IsFirstImage { get; set; }

    }
}
