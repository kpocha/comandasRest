using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Utils
    {
        public string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("hace {0} {1}",
                years, years == 1 ? "año" : "años");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("hace {0} {1}",
                months, months == 1 ? "mes" : "meses");
            }
            if (span.Days > 0)
                return String.Format("hace {0} {1}",
                span.Days, span.Days == 1 ? "día" : "días");
            if (span.Hours > 0)
                return String.Format("hace {0} {1}",
                span.Hours, span.Hours == 1 ? "hora" : "horas");
            if (span.Minutes > 0)
                return String.Format("hace {0} {1}",
                span.Minutes, span.Minutes == 1 ? "minuto" : "minutos");
            if (span.Seconds > 5)
                return String.Format("hace {0} segundos", span.Seconds);
            if (span.Seconds <= 5)
                return "justo ahora";
            return string.Empty;
        }

    }

}
