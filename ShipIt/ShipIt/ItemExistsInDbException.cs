using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt
{
	public class ItemExistsInDbException : Exception
	{
		public ItemExistsInDbException()
		{
		}

		public ItemExistsInDbException(string message) : base(message)
		{
		}

		public ItemExistsInDbException(string message, Exception inner) : base(message, inner)
		{
		}

		protected ItemExistsInDbException(SerializationInfo info, StreamingContext context)
		{
			// Add implementation.
		}
	}
}