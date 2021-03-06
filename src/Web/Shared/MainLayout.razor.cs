﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Helpers;
using NoteDotNet.Web.Models;

namespace NoteDotNet.Web.Shared
{
    public partial class MainLayout
    {
        [Inject]
        private IJsHelper JsHelper { get; set; }

        [Inject]
        private INoteService NoteService { get; set; }

        private AppState AppState { get; set; } = new AppState();

        private void OnSidebarQueryChanged(QueryChangedEventArgs eventArgs)
        {
            AppState.Query = eventArgs.Query;
            AppState.Limit = eventArgs.Limit;
            AppState.Property = eventArgs.SortProperty;
            AppState.Direction = eventArgs.SortDirection;
            AppState.LastActivity = DateTime.UtcNow;
        }

        private async Task OnNewNoteModalNoteCreatedAsync(NoteModel note)
        {
            await NoteService.CreateAsync(note);

            await JsHelper.CloseModal(NewNoteModal.Id);
        }

        private async Task OnDeleteNoteModalDeleteClickedAsync(NoteModel note)
        {
            await NoteService.DeleteAsync(note.Id);

            await JsHelper.CloseModal(DeleteNoteModal.Id);

            AppState.SetCurrentNote(null);

            AppState.LastActivity = DateTime.UtcNow;
        }
    }
}
