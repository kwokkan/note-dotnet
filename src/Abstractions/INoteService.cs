using System;
using System.Threading.Tasks;

namespace NoteDotNet.Abstractions
{
    public interface INoteService
    {
        Task<int> CreateAsync(NoteModel note);

        Task<NoteModel> GetAsync(int id);

        Task<CollectionModel<NoteModel>> SearchAsync(
            string query = null,
            int offset = 0,
            int limit = 2,
            SortProperty sortProperty = SortProperty.Updated,
            SortDirection sortDirection = SortDirection.Descending);

        Task UpdateAsync(int id, NoteModel note);

        event Action<NoteModel> OnNoteCreated;
    }
}
