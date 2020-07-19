using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public partial class Sidebar
    {
        protected string Query { get; set; }

        protected int Limit { get; set; }

        protected SortProperty Property { get; set; } = SortProperty.Updated;

        protected SortDirection Direction { get; set; } = SortDirection.Descending;

        [Parameter]
        public int DefaultLimit { get; set; }

        [Parameter]
        public EventCallback<QueryChangedEventArgs> OnQueryChanged { get; set; }

        protected override void OnInitialized()
        {
            Limit = DefaultLimit;

            base.OnInitialized();
        }

        protected void OnSubmit()
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
