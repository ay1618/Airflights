using System;
using System.Collections.Generic;
using System.Text;

namespace AirflightsShared.Enums
{
    public enum ResultCode
    {
        Ok = 0,
        Error = -1,
        ModelValidationError = -2,
        AuthorizationError = -3
    }
}
