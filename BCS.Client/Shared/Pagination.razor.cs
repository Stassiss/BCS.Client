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

        private List<PagingLink> _links;

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();

        }

        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();
            _links.Add(new PagingLink("Back", MetaData.CurrentPage - 1, MetaData.HasPrevious));
            for (int i = 1; i <= MetaData.TotalPages; i++)
            {
                if (i >= MetaData.CurrentPage - Spread && i <= MetaData.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i.ToString(), i, true) { Active = MetaData.CurrentPage == i });
                }
            }
            _links.Add(new PagingLink("Next", MetaData.CurrentPage + 1, MetaData.HasNext));
        }

        private async Task OnSelectedPage(PagingLink link)
        {

            if (link.Page == MetaData.CurrentPage || !link.Enabled)
            {
                return;
            }
            MetaData.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
