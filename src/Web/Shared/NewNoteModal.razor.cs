using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Data.Abstractions;
using NoteDotNet.Models;

namespace NoteDotNet.Web
{
    public class NewNoteModalComponentBase : ComponentBase
    {
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
        }
    }
}
