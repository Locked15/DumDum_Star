using System.ComponentModel.DataAnnotations;

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

        public string? Name { get; set; }

        [Required]
        public string Login { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string MailAddress { get; set; } = null!;

        public virtual ICollection<CyberWareMessage> CyberWareMessages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
