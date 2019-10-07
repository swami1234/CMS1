using CMS1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS1.Services
{
    public interface IAuthenticationService
    {
        bool Register(string email, string userName, string password);
        UserModal Login(string userName, string password);
    }
}
