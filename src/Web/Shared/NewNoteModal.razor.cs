using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web
{
    public class NewNoteModalComponentBase : ComponentBase
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; }

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

            await JSRuntime.InvokeVoidAsync("modalClose");
        }
    }
}
