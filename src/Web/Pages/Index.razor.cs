using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Data.Abstractions;
using NoteDotNet.Models;

namespace NoteDotNet.Web
{
    public class IndexComponentBase : ComponentBase
    {
        protected const int Limit = 2;

        [Inject]
        private INoteService NoteService { get; set; }

        protected CollectionModel<NoteModel> Notes { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Notes = await NoteService.SearchAsync();

            NoteService.OnNoteCreated += NoteService_OnNoteCreated;
        }

        private async void NoteService_OnNoteCreated(NoteModel obj)
        {
            Notes = await NoteService.SearchAsync();

            await InvokeAsync(StateHasChanged);
        }

        protected async Task ChangePageAsync(int page)
        {
            Notes = await NoteService.SearchAsync(offset: (page - 1) * Limit);

            await InvokeAsync(StateHasChanged);
        }
    }
}
