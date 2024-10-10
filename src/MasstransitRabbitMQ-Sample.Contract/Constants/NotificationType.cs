using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasstransitRabbitMQ_Sample.Contract.Enum
{
    public static class NotificationType
    {
        public static string sms = nameof(sms);
        public static string email = nameof(email);
    }
}
