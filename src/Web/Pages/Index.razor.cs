using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web
{
    public class IndexComponentBase : ComponentBase
    {
        [Inject]
        private INoteService NoteService { get; set; }

        [CascadingParameter(Name = nameof(Query))]
        protected string Query { get; set; }

        [CascadingParameter(Name = nameof(Limit))]
        protected int Limit { get; set; }

        [CascadingParameter(Name = nameof(Property))]
        protected SortProperty Property { get; set; }

        [CascadingParameter(Name = nameof(Direction))]
        protected SortDirection Direction { get; set; }

        protected CollectionModel<NoteModel> Notes { get; private set; }

        private int _offset = 0;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await SearchAsync();

            NoteService.OnNoteCreated += NoteService_OnNoteCreated;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            await SearchAsync();
        }

        private async void NoteService_OnNoteCreated(NoteModel obj)
        {
            await SearchAsync();
        }

        protected async Task ChangePageAsync(int offset)
        {
            _offset = offset;

            await SearchAsync();
        }

        private async Task SearchAsync()
        {
            Notes = await NoteService.SearchAsync(
                query: Query,
                offset: _offset,
                limit: Limit,
                sortProperty: Property,
                sortDirection: Direction);

            await InvokeAsync(StateHasChanged);
        }
    }
}
