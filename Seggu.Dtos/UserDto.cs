using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seggu.Dtos
{
    public class UserDto : EntityWithIdDto
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public short Role { get; set; }
    }
}
