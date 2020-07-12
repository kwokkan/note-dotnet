using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public class MainLayoutLayoutComponentBase : LayoutComponentBase
    {
        protected string Query { get; set; }

        public SortProperty Property { get; set; } = SortProperty.Updated;

        public SortDirection Direction { get; set; } = SortDirection.Descending;

        protected void OnSidebarQueryChanged(QueryChangedEventArgs eventArgs)
        {
            Query = eventArgs.Query;
            Property = eventArgs.SortProperty;
            Direction = eventArgs.SortDirection;
        }
    }
}
