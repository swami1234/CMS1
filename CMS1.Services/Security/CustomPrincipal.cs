using System.Linq;
using System.Security.Principal;

namespace CMS1.Services.Security
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public bool IsInRole(string role)
        {
            if (Roles.Any(r => role.Contains(r)))
            {
                return true;
            }

            return false;
        }
    }
}
