using System;

namespace Final_ProjectOOP
{
	public class OverCapacityException : Exception
	{
		public OverCapacityException(string message) : base(message)
        {
		}
    }
}
