using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fisher.Core.Data.Dtos;
using Fisher.Core.Services;
using Fisher.Core.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController :ControllerBase
    {
        private INotesService _notesService;
        private IMapper _mapper;

        public NotesController(INotesService notesService,IMapper mapper)
        {
            _notesService = notesService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetByFollowersAmount(int p=1,int s=10)
        {
            var notes = await _notesService.GetAllPublicByFollowersAmount(new PaginationRequest(p, s));
            return Ok(_mapper.Map<IEnumerable<NotePackageDto>>(notes));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var package = await _notesService.GetById(GetIdentityName(), id);
            return Ok(_mapper.Map<NotePackageDetailDto>(package));
        }

        [HttpGet("/category/{id}")]
        public async Task<IActionResult> GetByCategory(int id, int p = 1, int s = 10)
        {
            var notes = await _notesService.GetByCategory(id, new PaginationRequest(p, s));
            return Ok(_mapper.Map<IEnumerable<NotePackageDto>>(notes));
        }

        [HttpPost("{id}/follow")]
        public async Task<IActionResult> FollowPackage(int id)
        {
            await _notesService.FollowNotePackage(GetIdentityName(), id);
            return StatusCode(201);
        }
        
        [HttpPost("{id}/unfollow")]
        public async Task<IActionResult> UnfollowPackage(int id)
        {
            await _notesService.UnFollowNotePackage(GetIdentityName(), id);
            return StatusCode(201);
        }

        private string GetIdentityName() => HttpContext.User.Identity.Name;
    }
}