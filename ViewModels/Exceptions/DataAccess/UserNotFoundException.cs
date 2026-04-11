using System;

namespace ViewModels.Exceptions.DataAccess;

public class UserNotFoundException: Exception
{
    public UserNotFoundException(string userEmail): base($"User not found for email {userEmail}") 
    {
        
    }

    public UserNotFoundException(Guid id) : base($"User not found for id {id}")
    {

    }
}