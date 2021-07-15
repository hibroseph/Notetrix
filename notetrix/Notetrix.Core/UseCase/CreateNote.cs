using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notetrix.Core.Domain;
using Notetrix.Core.Repository;

namespace Notetrix.Core.UseCase
{
	public class CreateNote : ICreateNote
	{
		private readonly INoteRepository _noteRepository;

		public CreateNote( INoteRepository noteRepository )
		{
			_noteRepository = noteRepository;
		}

		public async Task<Note> CreateNoteAsync( int userId, string title, string content )
		{
			Note note = new Note( title, content );

			await _noteRepository.SaveNoteAsync( userId, note );

			return note;
		}
	}
}
