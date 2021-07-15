using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notetrix.Core.Domain
{
	public class Note
	{
		private string _title;
		private string _content;
		private Guid _id;

		public Note( string title, string content )
		{
			_title = title;
			_content = content;
			_id = Guid.NewGuid();
		}

		public Note( string title, string content, Guid id )
		{
			_title = title;
			_content = content;
			_id = id;
		}

		public Guid GetIdentifier()
		{
			return _id;
		}

		public string GetContent()
		{
			return _content;
		}

		public string GetTitle()
		{
			return _title;
		}
	}
}
