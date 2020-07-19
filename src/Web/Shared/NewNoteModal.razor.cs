using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Shared
{
    public partial class NewNoteModal
    {
        public const string Id = "new-note-modal";

        private NoteModel Model = new NoteModel();

        [Parameter]
        public EventCallback<NoteModel> OnNoteCreated { get; set; }

        private async Task OnSubmitAsync()
        {
            var newNote = new NoteModel
            {
                Content = Model.Content
            };

            await OnNoteCreated.InvokeAsync(newNote);
        }
    }
}
