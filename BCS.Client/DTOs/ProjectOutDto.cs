using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.DTOs
{
    public class ProjectOutDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public byte[] FirstImageData { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime LastModified { get; set; }
        public List<ImageOutDto> Images { get; set; }
    }
}
