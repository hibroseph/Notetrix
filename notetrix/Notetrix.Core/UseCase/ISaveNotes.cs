using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notetrix.Core.Domain;

namespace Notetrix.Core.UseCase
{
	public interface ISaveNotes
	{
		Task SaveNoteAsync( int userId, Note note );
	}
}
