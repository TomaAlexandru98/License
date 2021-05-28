using License.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Poco
{
    public class ServiceOption : IPoco
    {
        public Service Service { get; set; }

        public int ServiceId { get; set; }

        public Option Option { get; set; }

        public string OptionName { get; set; }
    }
}
