using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class Choom
    {
        public Choom()
        {
            CyberWareMessages = new HashSet<CyberWareMessage>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string MailAddress { get; set; } = null!;
        public string? Name { get; set; }

        public virtual ICollection<CyberWareMessage> CyberWareMessages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
