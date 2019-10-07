using System.Security.Principal;

namespace CMS1.Services.Security
{
    public interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string[] Roles { get; set; }
    }
}