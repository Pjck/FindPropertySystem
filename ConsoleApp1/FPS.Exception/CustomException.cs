using System;

namespace FPS.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException() : base()
        {

        }

        public CustomException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
