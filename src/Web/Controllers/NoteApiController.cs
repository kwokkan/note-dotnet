using System.Threading.Tasks;

using KwokKan.NoteDotNet.Models;

using Microsoft.AspNetCore.Mvc;

using NoteDotNet.Data.Abstractions;

namespace KwokKan.NoteDotNet.Web.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NoteApiController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteApiController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<ActionResult<NoteModel[]>> SearchAsync()
        {
            var notes = await _noteService.SearchAsync();

            return Ok(notes);
        }
    }
}
