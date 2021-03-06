﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;
using NoteDotNet.Web.Helpers;
using NoteDotNet.Web.Models;
using NoteDotNet.Web.Shared;

namespace NoteDotNet.Web.Pages
{
    public partial class Index
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IJsHelper JsHelper { get; set; }

        [Inject]
        private INoteService NoteService { get; set; }

        [CascadingParameter(Name = nameof(AppState))]
        private AppState AppState { get; set; }

        private CollectionModel<NoteModel> Notes { get; set; }

        private int _offset = 0;

        private DateTime _lastActivity;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await SearchAsync();

            NoteService.OnNoteCreated += NoteService_OnNoteCreated;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (AppState.LastActivity > _lastActivity)
            {
                _lastActivity = AppState.LastActivity;
                _offset = 0;
            }

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

        protected void NoteEditClicked(NoteModel note)
        {
            NavigationManager.NavigateTo($"/{note.Id}");
        }

        protected async Task NoteDeleteClickedAsync(NoteModel note)
        {
            AppState.SetCurrentNote(note);

            await JsHelper.ShowModal(DeleteNoteModal.Id);
        }

        private async Task SearchAsync()
        {
            Notes = await NoteService.SearchAsync(
                query: AppState.Query,
                offset: _offset,
                limit: AppState.Limit,
                sortProperty: AppState.Property,
                sortDirection: AppState.Direction);

            await InvokeAsync(StateHasChanged);
        }
    }
}
