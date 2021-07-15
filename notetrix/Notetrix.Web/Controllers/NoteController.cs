using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notetrix.Core.Domain;
using Notetrix.Core.UseCase;
using Notetrix.Web.Models.Note;

namespace Notetrix.Web.Controllers
{
	public class NoteController : Controller
	{
		private ISaveNotes _saveNotes;
		private ILoadNotes _loadNotes;
		private ICreateNote _createNote;

		public NoteController( ISaveNotes saveNotes, ILoadNotes loadNotes, ICreateNote createNote )
		{
			_saveNotes = saveNotes;
			_loadNotes = loadNotes;
			_createNote = createNote;
		}

		public async Task<IActionResult> Index( int userId )
		{
			var notes = await _loadNotes.LoadNotesAsync( userId );


			return View( BuildNoteModel( notes ) );
		}

		[HttpPost]
		public async Task<IActionResult> CreateNote( int userId )
		{
			Note note = await _createNote.CreateNoteAsync( userId, "Nice Lil Title", "Put your amazing content here pls" );

			return new JsonResult( BuildIndividualNoteModel( note ) );
		}

		[HttpPatch]
		public async Task<IActionResult> UpdateNote( int userId, Guid noteId, [FromBody] string title, [FromBody] string content )
		{
			await _saveNotes.SaveNoteAsync( userId, new Note( title, content, noteId ) );

			return StatusCode( 200 );
		}

		private NoteModel BuildNoteModel( List<Note> notes )
		{
			return new NoteModel
			{
				Notes = BuildNotesModel( notes )
			};
		}

		private IndividualNoteModel BuildIndividualNoteModel( Note note )
		{
			return new IndividualNoteModel
			{
				Content = note.GetContent(),
				Id = note.GetIdentifier().ToString(),
				Title = note.GetTitle()
			};
		}

		private List<IndividualNoteModel> BuildNotesModel( List<Note> notes )
		{
			return notes.Select( p =>
				new IndividualNoteModel
				{
					Content = p.GetContent(),
					Title = p.GetTitle(),
					Id = p.GetIdentifier().ToString()
				} ).ToList();
		}
	}
}
