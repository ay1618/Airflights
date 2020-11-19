using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
