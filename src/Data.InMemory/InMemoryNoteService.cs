using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NoteDotNet.Data.Abstractions;
using NoteDotNet.Models;

namespace NoteDotNet.Data.InMemory
{
    public class InMemoryNoteService : INoteService
    {
        private static IDictionary<int, NoteModel> _notes;
        private static int _nextId;

        public InMemoryNoteService()
        {
            SeedData();
        }

        public event Action<NoteModel> OnNoteCreated;

        Task<int> INoteService.CreateAsync(NoteModel note)
        {
            var now = DateTime.UtcNow;
            var newNote = new NoteModel
            {
                Id = _nextId++,
                Created = now,
                Updated = now,
                Content = note.Content,
                Tags = note.Tags
            };

            _notes.Add(newNote.Id, newNote);

            OnNoteCreated?.Invoke(newNote);

            return Task.FromResult(newNote.Id);
        }

        Task<NoteModel> INoteService.GetAsync(int id)
        {
            if (_notes.TryGetValue(id, out var note))
            {
                return Task.FromResult(note);
            }

            throw new Exception("Note not found");
        }

        Task<CollectionModel<NoteModel>> INoteService.SearchAsync(int offset, int limit)
        {
            var notes = _notes.Values.OrderByDescending(x => x.Updated).Skip(offset).Take(limit).ToArray();

            var collection = new CollectionModel<NoteModel>
            {
                Offset = offset,
                Total = _notes.Count,
                Items = notes,
            };

            return Task.FromResult(collection);
        }

        private static void SeedData()
        {
            _notes = new Dictionary<int, NoteModel>();

            var now = DateTime.UtcNow;
            _notes.Add(1, new NoteModel
            {
                Id = 1,
                Created = now,
                Updated = now,
                Content = "# Hello World"
            });

            _notes.Add(2, new NoteModel
            {
                Id = 2,
                Created = now,
                Updated = now,
                Content = "# With tags",
                Tags = new string[]
                {
                    "first tag",
                    "test"
                }
            });

            _notes.Add(3, new NoteModel
            {
                Id = 3,
                Created = now,
                Updated = now,
                Content = "# More tags",
                Tags = new string[]
                {
                    "test",
                    "more tag"
                }
            });

            _nextId = _notes.Count + 1;
        }
    }
}
