using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayBakery.Web.Enum
{
    public class Notify
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        }
    }
}
