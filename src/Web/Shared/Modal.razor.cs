using Microsoft.AspNetCore.Components;

namespace NoteDotNet.Web.Shared
{
    public class ModalComponentBase : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
