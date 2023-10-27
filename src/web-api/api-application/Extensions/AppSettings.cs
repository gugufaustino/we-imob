using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoMinutos { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public string[] CorsOrigins { get; set; }
    }
}
