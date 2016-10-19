using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Global.Auth
{
    interface IUserProvider
    {
        User User { get; set; }
    }
}
