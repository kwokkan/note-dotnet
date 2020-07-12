using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Shared
{
    public class NoteComponentBase : ComponentBase
    {
        [Parameter]
        public NoteModel Note { get; set; }
    }
}
