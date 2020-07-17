using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteDotNet.Abstractions.InMemory
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

        Task INoteService.DeleteAsync(int id)
        {
            if (_notes.ContainsKey(id))
            {
                _notes.Remove(id);

                return Task.CompletedTask;
            }

            throw new Exception("Note not found");
        }

        Task<NoteModel> INoteService.GetAsync(int id)
        {
            if (_notes.TryGetValue(id, out var note))
            {
                var cloned = note.DeepClone();
                return Task.FromResult(cloned);
            }

            throw new Exception("Note not found");
        }

        Task<CollectionModel<NoteModel>> INoteService.SearchAsync(
            string query,
            int offset,
            int limit,
            SortProperty sortProperty,
            SortDirection sortDirection)
        {
            IEnumerable<NoteModel> q = _notes.Values;

            if (!string.IsNullOrEmpty(query))
            {
                q = q.Where(x => x.Content.Contains(query, StringComparison.CurrentCultureIgnoreCase));
            }

            var total = q.Count();

            switch (sortProperty)
            {
                case SortProperty.Created:
                    q = sortDirection == SortDirection.Descending ? q.OrderByDescending(x => x.Created) : q.OrderBy(x => x.Created);
                    break;
                case SortProperty.Updated:
                default:
                    q = sortDirection == SortDirection.Descending ? q.OrderByDescending(x => x.Updated) : q.OrderBy(x => x.Updated);
                    break;
            }

            q = q.Skip(offset).Take(limit);

            var notes = q.ToArray();

            var collection = new CollectionModel<NoteModel>
            {
                Offset = offset,
                Total = total,
                Items = notes,
            };

            return Task.FromResult(collection);
        }

        Task INoteService.UpdateAsync(int id, NoteModel note)
        {
            if (_notes.TryGetValue(id, out var existing))
            {
                var cloned = note.DeepClone();

                existing.Updated = DateTime.UtcNow;
                existing.Content = cloned.Content;
                existing.Tags = cloned.Tags;

                return Task.CompletedTask;
            }

            throw new Exception("Note not found");
        }

        private static void SeedData()
        {
            _notes = new Dictionary<int, NoteModel>();

            var now = DateTime.UtcNow;
            _notes.Add(1, new NoteModel
            {
                Id = 1,
                Created = now.AddDays(-7),
                Updated = now.AddDays(-7),
                Content = "# Hello World"
            });

            _notes.Add(2, new NoteModel
            {
                Id = 2,
                Created = now.AddDays(-3),
                Updated = now.AddDays(-3),
                Content = "# With tags",
                Tags = new HashSet<string>
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
                Tags = new HashSet<string>
                {
                    "test",
                    "more tag"
                }
            });

            _nextId = _notes.Count + 1;
        }
    }
}
