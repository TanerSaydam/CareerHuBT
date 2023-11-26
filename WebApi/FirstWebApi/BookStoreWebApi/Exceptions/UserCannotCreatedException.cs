using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApi.Exceptions;

public sealed class UserCannotCreatedException : Exception
{
    public UserCannotCreatedException(IdentityError err) : base($"Hata: {err.Code} - {err.Description}")
    {
    }
}