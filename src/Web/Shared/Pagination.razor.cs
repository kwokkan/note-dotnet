using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

namespace NoteDotNet.Web.Shared
{
    public partial class Pagination
    {
        [Parameter]
        public int Offset { get; set; }

        [Parameter]
        public int Limit { get; set; }

        [Parameter]
        public int Total { get; set; }

        [Parameter]
        public EventCallback<int> OnPageChanged { get; set; }

        private int CurrentPage { get; set; }

        private int TotalPages { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            UpdateState();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            UpdateState();
        }

        private Task ChangePage(int page)
        {
            CurrentPage = page;

            return InvokeAsync(async () =>
            {
                await OnPageChanged.InvokeAsync((page * Limit) - Limit);
                UpdateState();
            });
        }

        private void UpdateState()
        {
            CurrentPage = (int)(Offset == 0 ? 0 : Math.Ceiling(Offset / (double)Limit)) + 1;
            TotalPages = (int)(Total == 0 ? 1 : Math.Ceiling(Total / (double)Limit));

            StateHasChanged();
        }
    }
}
