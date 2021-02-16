using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.DTOs
{
    public class ImageOutDto
    {
        public Guid Id { get; set; }
        public byte[] ImageData { get; set; }
        public bool IsFirstImage { get; set; }

        public string FileType { get; set; }
        public long FileSize { get; set; }
        public Guid ProjectId { get; set; }
    }
}
