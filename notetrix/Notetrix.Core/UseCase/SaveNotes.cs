using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Notetrix.Core.Domain;
using Notetrix.Core.Repository;

namespace Notetrix.Core.UseCase
{
	public class SaveNotes : ISaveNotes
	{
		private readonly INoteRepository _noteRepository;

		public SaveNotes( INoteRepository noteRepository )
		{
			_noteRepository = noteRepository;
		}

		public Task SaveNoteAsync( int userId, Note note )
		{
			try
			{
				return _noteRepository.SaveNoteAsync( userId, note );
			}
			catch ( Exception e )
			{

			}

			return Task.CompletedTask;
		}
	}
}
