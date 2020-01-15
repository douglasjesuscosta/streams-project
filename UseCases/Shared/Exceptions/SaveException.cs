using System;
namespace UseCases.Shared.Exceptions
{
    public class SaveException : Exception
    {
        public SaveException(string message) : base(message)
        {
        }
    }
}
