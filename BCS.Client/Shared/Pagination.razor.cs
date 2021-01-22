using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCS.Client.Features;
using Microsoft.AspNetCore.Components;

namespace BCS.Client.Shared
{
    public partial class Pagination
    {
        [Parameter]
        public MetaData MetaData { get; set; }
        [Parameter]
        public int Spread { get; set; }
        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }


    }
}
