using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public class MainLayoutLayoutComponentBase : LayoutComponentBase
    {
        protected string Query { get; set; }

        protected int Limit { get; set; } = 1;

        protected SortProperty Property { get; set; } = SortProperty.Updated;

        protected SortDirection Direction { get; set; } = SortDirection.Descending;

        protected void OnSidebarQueryChanged(QueryChangedEventArgs eventArgs)
        {
            Query = eventArgs.Query;
            Property = eventArgs.SortProperty;
            Direction = eventArgs.SortDirection;
        }
    }
}
