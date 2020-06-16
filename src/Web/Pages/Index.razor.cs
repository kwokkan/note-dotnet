using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Data.Abstractions;
using NoteDotNet.Models;

namespace NoteDotNet.Web
{
    public class IndexComponentBase : ComponentBase
    {
        [Inject]
        private INoteService NoteService { get; set; }

        protected NoteModel[] Notes { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Notes = await NoteService.SearchAsync();
        }
    }
}
