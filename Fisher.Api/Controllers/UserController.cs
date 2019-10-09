using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fisher.Core.Data.Dtos;
using Fisher.Core.Domain;
using Fisher.Core.Services;
using Fisher.Core.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IMapper _mapper;
        private IUserNotesService _userNotesService;
        private IFileConverter<Note> _converter;

        public UserController(IUserNotesService userNotesService,IMapper mapper ,IFileConverter<Note> converter)
        {
            _userNotesService = userNotesService;
            _mapper = mapper;
            _converter = converter;
        }
        
        [HttpGet("favorite")]
        public async Task<IActionResult> FavoriteList()
        {
            var favoriteList = await _userNotesService.GetUserFavoritePackages(GetIdentityName());
            return Ok(_mapper.Map<FavoriteNoteDto>(favoriteList));
        }

        [HttpGet("notes")]
        public async Task<IActionResult> GetUserNotes()
        {
            var userNotePackages = await _userNotesService.GetUserNotes(GetIdentityName());
            return Ok(_mapper.Map<NotePackageDto>(userNotePackages));
        }

        [HttpPost("notes")]
        public async Task<IActionResult> AddNotePackage(NotePackageDetailDto notePackageDetailDto)
        {
            var notePackage = _mapper.Map<NotePackage>(notePackageDetailDto);
            await _userNotesService.AddNotePackage(GetIdentityName(), notePackage);
            return Ok();
        }

        [HttpPost("notes")]
        public async Task<IActionResult> ImportFromFile(IFormFile file, NotePackageDetailDto dto)
        {
            var notes = _converter.Convert(file);
            var nodePackage = new NotePackage()
            {
                Title = dto.Title,
                Category = new Category() {Id = dto.CategoryId},
                Notes = notes.ToList()
            };
            await _userNotesService.AddNotePackage(GetIdentityName(), nodePackage);
            return StatusCode(201);
        }

        private string GetIdentityName() => HttpContext.User.Identity.Name;
    }
}