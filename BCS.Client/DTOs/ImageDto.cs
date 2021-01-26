using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.DTOs
{
    public class ImageDto
    {
        public Guid ProjectId { get; set; }
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
    }
}
