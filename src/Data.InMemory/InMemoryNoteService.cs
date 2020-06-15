using System.Threading.Tasks;

using KwokKan.NoteDotNet.Models;

using NoteDotNet.Data.Abstractions;

namespace NoteDotNet.Data.InMemory
{
    public class InMemoryNoteService : INoteService
    {
        Task<int> INoteService.CreateAsync(NoteModel note)
        {
            throw new System.NotImplementedException();
        }

        Task<NoteModel> INoteService.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<NoteModel[]> INoteService.SearchAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
