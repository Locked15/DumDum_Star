using System;
using System.Collections.Generic;

namespace DumDum_Star.Models.Entities
{
    public partial class Order
    {
        public Order()
        {
            CyberWareToOrders = new HashSet<CyberWareToOrder>();
        }

        public int Id { get; set; }
        public int ChoomId { get; set; }
        public int AddressId { get; set; }
        public DateTime ChippinTime { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual Choom Choom { get; set; } = null!;
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
