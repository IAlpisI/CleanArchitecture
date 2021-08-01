using System;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id, string name) : base($"{name} not found {id}")
        {

        }
    }
}
