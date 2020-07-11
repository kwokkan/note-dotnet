using System;
using System.Threading.Tasks;

using NoteDotNet.Models;

namespace NoteDotNet.Data.Abstractions
{
    public interface INoteService
    {
        Task<int> CreateAsync(NoteModel note);

        Task<NoteModel> GetAsync(int id);

        Task<CollectionModel<NoteModel>> SearchAsync(int offset = 0, int limit = 2);

        event Action<NoteModel> OnNoteCreated;
    }
}
