using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Pages
{
    public class ViewComponentBase : ComponentBase
    {
        [Inject]
        private INoteService NoteService { get; set; }

        [Parameter]
        public int Id { get; set; }

        protected NoteModel Note { get; private set; }

        protected string CurrentTagText { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Note = await NoteService.GetAsync(Id);
        }

        protected async Task OnSaveNoteClickedAsync()
        {
            await NoteService.UpdateAsync(Id, Note);
        }

        protected void OnCurrentTagTextKeyUp(KeyboardEventArgs eventArgs)
        {
            if (eventArgs.Key == "Enter")
            {
                Note.Tags.Add(CurrentTagText);

                CurrentTagText = null;
            }
        }

        protected void OnTagDeleteClicked(string tag)
        {
            Note.Tags.Remove(tag);
        }
    }
}
