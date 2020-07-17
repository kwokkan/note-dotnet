using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web
{
    public class NewNoteModalComponentBase : ComponentBase
    {
        public const string Id = "new-note-modal";

        protected NoteModel Model = new NoteModel();

        [Parameter]
        public EventCallback<NoteModel> OnNoteCreated { get; set; }

        protected async Task OnSubmitAsync()
        {
            var newNote = new NoteModel
            {
                Content = Model.Content
            };

            await OnNoteCreated.InvokeAsync(newNote);
        }
    }
}
