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

        [CascadingParameter(Name = "Query")]
        protected string Query { get; set; }

        protected CollectionModel<NoteModel> Notes { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Notes = await NoteService.SearchAsync(query: Query);

            NoteService.OnNoteCreated += NoteService_OnNoteCreated;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            Notes = await NoteService.SearchAsync(query: Query);

            await InvokeAsync(StateHasChanged);
        }

        private async void NoteService_OnNoteCreated(NoteModel obj)
        {
            Notes = await NoteService.SearchAsync(query: Query);

            await InvokeAsync(StateHasChanged);
        }

        protected async Task ChangePageAsync(int offset)
        {
            Notes = await NoteService.SearchAsync(query: Query, offset: offset);

            await InvokeAsync(StateHasChanged);
        }
    }
}
