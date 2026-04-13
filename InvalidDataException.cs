using System;

namespace Final_ProjectOOP
{
	public class InvalidDataException : Exception
	{
		public InvalidDataException(string message) : base(message)
        {
	    }
	}
}
