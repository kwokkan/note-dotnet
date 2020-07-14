using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Shared
{
    public class NoteComponentBase : ComponentBase
    {
        [Parameter]
        public NoteModel Note { get; set; }

        [Parameter]
        public EventCallback<NoteModel> OnEditClicked { get; set; }

        [Parameter]
        public EventCallback<NoteModel> OnDeleteClicked { get; set; }

        protected void EditClicked()
        {
            OnEditClicked.InvokeAsync(Note);
        }

        protected void DeleteClicked()
        {
            OnDeleteClicked.InvokeAsync(Note);
        }
    }
}
