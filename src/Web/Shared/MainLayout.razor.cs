using Microsoft.AspNetCore.Components;

namespace NoteDotNet.Web.Shared
{
    public class MainLayoutLayoutComponentBase : LayoutComponentBase
    {
        protected string Query { get; set; }

        protected void OnSidebarQueryChanged(string query)
        {
            Query = query;
        }
    }
}
