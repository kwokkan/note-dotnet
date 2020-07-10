using System;
using System.Threading.Tasks;

using NoteDotNet.Models;

namespace NoteDotNet.Data.Abstractions
{
    public interface INoteService
    {
        Task<int> CreateAsync(NoteModel note);

        Task<NoteModel> GetAsync(int id);

        Task<NoteModel[]> SearchAsync();

        event Action<NoteModel> OnNoteCreated;
    }
}
