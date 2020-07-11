using Microsoft.AspNetCore.Components;

namespace NoteDotNet.Web.Shared
{
    public class SidebarComponentBase : ComponentBase
    {
        protected string Query { get; set; }

        [Parameter]
        public EventCallback<string> OnQueryChanged { get; set; }

        protected void OnSubmit()
        {
            OnQueryChanged.InvokeAsync(Query);
        }
    }
}
