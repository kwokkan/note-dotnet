using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Shared;

namespace NoteDotNet.Web.Pages
{
    public class ViewComponentBase : LoadableComponentBase<NoteModel>
    {
        [Inject]
        private INoteService NoteService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected string CurrentTagText { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await LoadAsync(async () => await NoteService.GetAsync(Id));
        }

        protected async Task OnSaveNoteClickedAsync()
        {
            await NoteService.UpdateAsync(Id, Model);

            NavigationManager.NavigateTo("/");
        }

        protected void OnCurrentTagTextKeyUp(KeyboardEventArgs eventArgs)
        {
            if (eventArgs.Key == "Enter")
            {
                AddTag();
            }
        }

        protected void OnTagDeleteClicked(string tag)
        {
            Model.Tags.Remove(tag);
        }

        protected void AddTag()
        {
            Model.Tags.Add(CurrentTagText);

            CurrentTagText = null;
        }
    }
}
