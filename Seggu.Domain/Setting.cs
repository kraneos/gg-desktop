using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Seggu.Domain
{
    public class Setting
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string ClientsRole { get; set; }
        public string ObjectId { get; set; }
        public string Email { get; set; }
        public string SegguClientId { get; set; }
    }
}
