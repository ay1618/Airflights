﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDomain.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}