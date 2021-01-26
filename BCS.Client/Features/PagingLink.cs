using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.Features
{
    public class PagingLink
    {
        public PagingLink(string text, int page, bool enabled)
        {
            Text = text;
            Page = page;
            Enabled = enabled;
        }

        public string Text { get; set; }
        public bool Active { get; set; }
        public int Page { get; set; }
        public bool Enabled { get; set; }

    }
}
