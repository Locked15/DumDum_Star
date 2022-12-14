using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DumDum_Star.Models.Entities
{
    public partial class Order
    {
        public Order()
        {
            CyberWareToOrders = new HashSet<CyberWareToOrder>();
        }

        [Key]
        public int Id { get; set; }

        public int ChoomId { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public DateTime ChippinTime { get; set; } = DateTime.Today.AddDays(1);

        public virtual Choom Choom { get; set; } = null!;

        public virtual Address Address { get; set; } = null!;

        public virtual ICollection<CyberWareToOrder> CyberWareToOrders { get; set; }

        public decimal OrderPrice
        {
            get
            {
                var cyberWarePrices = CyberWareToOrders.Select(cyb => cyb.FinalPrice);

                return cyberWarePrices.Sum(cup => cup);
            }
        }
    }
}
