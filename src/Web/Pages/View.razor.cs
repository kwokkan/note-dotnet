using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Pages
{
    public partial class View
    {
        [Inject]
        private INoteService NoteService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private NoteModel Model;

        private string CurrentTagText { get; set; }

        [Parameter]
        public int Id { get; set; }

        private async Task OnSaveNoteClickedAsync()
        {
            await NoteService.UpdateAsync(Id, Model);

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
            Model.Tags.Remove(tag);
        }

        private void AddTag()
        {
            Model.Tags.Add(CurrentTagText);

            CurrentTagText = null;
        }

        private async Task<NoteModel> LoadNoteAsync()
        {
            Model = await NoteService.GetAsync(Id);

            return Model;
        }
    }
}
