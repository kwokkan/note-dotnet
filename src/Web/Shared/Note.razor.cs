using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Shared
{
    public partial class Note
    {
        [Parameter]
        public NoteModel Model { get; set; }

        [Parameter]
        public EventCallback<NoteModel> OnEditClicked { get; set; }

        [Parameter]
        public EventCallback<NoteModel> OnDeleteClicked { get; set; }

        private void EditClicked()
        {
            OnEditClicked.InvokeAsync(Model);
        }

        private void DeleteClicked()
        {
            OnDeleteClicked.InvokeAsync(Model);
        }
    }
}
