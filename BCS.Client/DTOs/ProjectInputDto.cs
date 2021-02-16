using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.DTOs
{
    public class ProjectInputDto
    {
        [Required]
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value.Trim().ToLower();
                _title = _title.Substring(0, 1).ToUpper() + _title.Substring(1);
            }
        }

        [Required]
        public string Description { get; set; }
        [Required]
        public List<ImageDto> Images { get; set; }
    }
}
