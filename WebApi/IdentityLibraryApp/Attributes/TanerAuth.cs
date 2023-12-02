using Microsoft.AspNetCore.Mvc.Filters;

namespace IdentityLibraryApp.Attributes;

public class TanerAuth : Attribute, IAuthorizationFilter
{
    private string _role;
    public TanerAuth(string role)
    {
        _role = role ?? string.Empty;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //var result = context.HttpContext.Request.Headers.Where(p => p.Key == "TanerAuth").Select(s=> s.Value).FirstOrDefault();

        var result = context.HttpContext.User.Claims;
        //if (string.IsNullOrEmpty(result))
        //{
        //    throw new UnAuthentication();
        //}
    }
}


public class UnAuthentication : Exception
{
    public UnAuthentication() : base("Kullanıcı girişi geçersiz!")
    {
        
    }
}