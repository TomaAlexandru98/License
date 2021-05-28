using License.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models.Poco
{
    public class User : IPoco
    {
        public string IdentityUserId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime MemberSince { get; set; }

        public string Description { get; set; }
    }
}
