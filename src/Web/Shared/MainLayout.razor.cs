using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Helpers;
using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public class MainLayoutLayoutComponentBase : LayoutComponentBase
    {
        [Inject]
        private IJsHelper JsHelper { get; set; }

        [Inject]
        private INoteService NoteService { get; set; }

        protected AppState AppState { get; set; } = new AppState();

        protected void OnSidebarQueryChanged(QueryChangedEventArgs eventArgs)
        {
            AppState.Query = eventArgs.Query;
            AppState.Limit = eventArgs.Limit;
            AppState.Property = eventArgs.SortProperty;
            AppState.Direction = eventArgs.SortDirection;
            AppState.LastActivity = DateTime.UtcNow;
        }

        protected async Task OnDeleteNoteModalDeleteClickedAsync(NoteModel note)
        {
            await NoteService.DeleteAsync(note.Id);

            await JsHelper.CloseModal(DeleteNoteModalComponentBase.Id);

            AppState.SetCurrentNote(null);

            AppState.LastActivity = DateTime.UtcNow;
        }
    }
}
