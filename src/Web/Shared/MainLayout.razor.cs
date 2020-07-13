using System;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public class MainLayoutLayoutComponentBase : LayoutComponentBase
    {
        protected AppState AppState { get; set; } = new AppState();

        protected void OnSidebarQueryChanged(QueryChangedEventArgs eventArgs)
        {
            AppState.Query = eventArgs.Query;
            AppState.Limit = eventArgs.Limit;
            AppState.Property = eventArgs.SortProperty;
            AppState.Direction = eventArgs.SortDirection;
            AppState.LastActivity = DateTime.UtcNow;
        }
    }
}
