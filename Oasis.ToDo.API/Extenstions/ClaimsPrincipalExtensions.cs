using System.Security.Claims;

namespace Oasis.ToDoAPP.API.Extentions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.First(id => id.Type == "UserId")?.Value);
        }
    }
}
