using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public partial class Sidebar
    {
        private string Query { get; set; }

        private int Limit { get; set; }

        private SortProperty Property { get; set; } = SortProperty.Updated;

        private SortDirection Direction { get; set; } = SortDirection.Descending;

        [Parameter]
        public int DefaultLimit { get; set; }

        [Parameter]
        public EventCallback<QueryChangedEventArgs> OnQueryChanged { get; set; }

        protected override void OnInitialized()
        {
            Limit = DefaultLimit;

            base.OnInitialized();
        }

        private void OnSubmit()
        {
            var args = new QueryChangedEventArgs
            {
                Query = Query,
                Limit = Limit,
                SortDirection = Direction,
                SortProperty = Property
            };
            OnQueryChanged.InvokeAsync(args);
        }
    }
}
