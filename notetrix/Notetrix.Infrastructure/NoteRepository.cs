using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notetrix.Core;
using Notetrix.Core.Domain;
using Notetrix.Core.Repository;

namespace Notetrix.Infrastructure
{
	public class NoteRepository : INoteRepository
	{
		private Dictionary<int, Dictionary<Guid, Note>> _usersNotes;

		public NoteRepository()
		{
			_usersNotes = new Dictionary<int, Dictionary<Guid, Note>>();
		}

		public Task SaveNoteAsync( int userId, Note note )
		{
			if ( DoesUserHaveNote( userId ) )
			{
				if ( DoesNoteExistForUser( userId, note ) )
				{
					_usersNotes[userId][note.GetIdentifier()] = note;
				}
				else
				{
					_usersNotes[userId].Add( note.GetIdentifier(), note );
				}

				return Task.CompletedTask;
			}

			_usersNotes.Add( userId, new Dictionary<Guid, Note>
			{
				{ note.GetIdentifier(), note}
			} );

			return Task.CompletedTask;
		}

		private bool DoesUserHaveNote( int userId )
		{
			return _usersNotes.ContainsKey( userId );
		}

		private bool DoesNoteExistForUser( int userId, Note note )
		{
			return _usersNotes[userId].ContainsKey( note.GetIdentifier() );
		}

		public Task<List<Note>> GetNotesAsync( int userId )
		{
			if ( DoesUserHaveNote( userId ) )
			{
				return Task.FromResult( _usersNotes[userId].Values.ToList() );
			}

			return Task.FromResult( new List<Note>() );
		}
	}
}
