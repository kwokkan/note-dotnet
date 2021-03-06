﻿using System;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Models
{
    public class AppState
    {
        public string Query { get; set; }

        public int Limit { get; set; } = 1;

        public SortProperty Property { get; set; } = SortProperty.Updated;

        public SortDirection Direction { get; set; } = SortDirection.Descending;

        public DateTime LastActivity { get; set; }

        public NoteModel CurrentNote { get; set; }

        public void SetCurrentNote(NoteModel note)
        {
            CurrentNote = note;
        }
    }
}
