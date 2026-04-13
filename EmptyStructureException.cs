using System;

namespace Final_ProjectOOP
{
    public class EmptyStructureException : Exception
    {
        public EmptyStructureException(string message) : base(message)
        {
        }
    }
}