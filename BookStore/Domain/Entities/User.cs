using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public partial class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime AddedDate { get; set; }
        public string ActivatedLink { get; set; }
        public List<Role> Roles { get; set; }
        public User()
        {
            Roles = new List<Role>();
        }
    }
    public partial class User
    {
        public static string GetActivateUrl()
        {
            return Guid.NewGuid().ToString("N");
        }
        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var role in rolesArray)
            {
                var hasRole = Roles.Any(p => string.Compare(p.Code, role, true) == 0);
                if (hasRole)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
