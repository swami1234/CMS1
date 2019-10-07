using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Services.Security
{
    [Serializable]
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
