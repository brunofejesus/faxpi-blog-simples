namespace FaxpiBlogSimples.App.Helpers
{
  public static class UserHelper
  {
    public static string? ObterIdentificadorDoUsuario(HttpContext httpContext)
    {
      var user = httpContext?.User;
      if (user?.Identity?.IsAuthenticated == true)
      {
        return user.FindFirst("identificador")?.Value;
      }

      return null;
    }
  }
}