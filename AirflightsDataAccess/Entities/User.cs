using AirflightsDataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public UserType Type { get; set; }
        public string Password { get; set; }
    }
}
