using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notetrix.Core.Domain;
using Notetrix.Core.Repository;

namespace Notetrix.Core.UseCase
{
	public class LoadNotes : ILoadNotes
	{
		private readonly INoteRepository _noteRepository;

		public LoadNotes( INoteRepository noteRepository )
		{
			_noteRepository = noteRepository;
		}

		public Task<List<Note>> LoadNotesAsync( int userId )
		{
			try
			{
				return _noteRepository.GetNotesAsync( userId );
			}
			catch ( Exception ex )
			{

			}

			return Task.FromResult( new List<Note>() );
		}
	}
}
