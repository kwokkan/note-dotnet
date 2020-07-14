using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using NoteDotNet.Abstractions;
using NoteDotNet.Web.Helpers;

namespace NoteDotNet.Web
{
    public class NewNoteModalComponentBase : ComponentBase
    {
        public const string Id = "new-note-modal";

        [Inject]
        private IJsHelper JsHelper { get; set; }

        [Inject]
        private INoteService NoteService { get; set; }

        protected NoteModel Model = new NoteModel();

        [Parameter]
        public EventCallback<int> OnNoteCreated { get; set; }

        protected async Task OnSubmitAsync()
        {
            var newNote = new NoteModel
            {
                Content = Model.Content
            };

            var newId = await NoteService.CreateAsync(newNote);

            await OnNoteCreated.InvokeAsync(newId);

            await JsHelper.CloseModal(Id);
        }
    }
}
