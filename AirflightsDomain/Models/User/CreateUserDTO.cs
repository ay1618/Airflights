using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.User
{
    public class CreateUserDTO
    {
        public String Login { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
    }
}
