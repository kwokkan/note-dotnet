using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Shared
{
    public partial class DeleteNoteModal
    {
        public const string Id = "delete-note-modal";

        [Parameter]
        public NoteModel Note { get; set; }

        [Parameter]
        public EventCallback<NoteModel> OnDeletedClicked { get; set; }

        protected async Task DeleteClickedAsync()
        {
            await OnDeletedClicked.InvokeAsync(Note);
        }
    }
}
