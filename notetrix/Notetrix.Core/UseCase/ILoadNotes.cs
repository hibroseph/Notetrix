using System.Collections.Generic;
using System.Threading.Tasks;
using Notetrix.Core.Domain;

namespace Notetrix.Core.UseCase
{
	public interface ILoadNotes
	{
		public Task<List<Note>> LoadNotesAsync( int userId );
	}
}