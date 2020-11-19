using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.User
{
    public class AuthUserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
    }
}
