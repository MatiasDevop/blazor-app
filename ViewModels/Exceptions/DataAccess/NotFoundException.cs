using System;

namespace ViewModels.Exceptions.DataAccess;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
            
    }
}