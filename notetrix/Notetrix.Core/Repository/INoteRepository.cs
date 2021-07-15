using System.Collections.Generic;
using System.Threading.Tasks;
using Notetrix.Core.Domain;

namespace Notetrix.Core.Repository
{
	public interface INoteRepository
	{
		public Task SaveNoteAsync( int userId, Note note );
		public Task<List<Note>> GetNotesAsync( int userId );
	}
}
