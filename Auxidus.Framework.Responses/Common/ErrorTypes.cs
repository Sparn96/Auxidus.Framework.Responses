using System;
using System.Collections.Generic;
using System.Text;

namespace Auxidus.Framework.Responses.Common
{
    public enum ResponseStatus
    {
        SUCCESS,
        GENERIC_FAILURE,
        VALIDATION_FAILED,
        CONTRACT_ERROR,
        DATABASE_ERROR
    }
}
