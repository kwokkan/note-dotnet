using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Pages
{
    public partial class View
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private INoteService NoteService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private NoteModel Note;

        private string CurrentTagText { get; set; }

        private async Task OnSaveNoteClickedAsync()
        {
            await NoteService.UpdateAsync(Id, Note);

            NavigationManager.NavigateTo("/");
        }

        private void OnCurrentTagTextKeyUp(KeyboardEventArgs eventArgs)
        {
            if (eventArgs.Key == "Enter")
            {
                AddTag();
            }
        }

        private void OnTagDeleteClicked(string tag)
        {
            Note.Tags.Remove(tag);
        }

        private void AddTag()
        {
            Note.Tags.Add(CurrentTagText);

            CurrentTagText = null;
        }

        private async Task<NoteModel> LoadNoteAsync()
        {
            Note = await NoteService.GetAsync(Id);

            return Note;
        }
    }
}
