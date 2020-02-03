using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Messages.Request.User
{
    public class FindUserByEmailRequest
    {
        public string Email { get; set; }
    }
}
