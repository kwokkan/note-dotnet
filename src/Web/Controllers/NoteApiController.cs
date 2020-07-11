using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Controllers
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
