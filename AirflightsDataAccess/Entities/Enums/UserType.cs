using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsDataAccess.Entities.Enums
{
    /// <summary>
    /// тип пользователя
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// обычный пользователь - клиент
        /// </summary>
        Client = 0,

        /// <summary>
        /// Администратор
        /// </summary>
        Admin = 1,

        /// <summary>
        /// Модератор
        /// </summary>
        Moderator = 2
    }
}
