using DumDum_Star.Models.Entities;

namespace DumDum_Star.Models.Views
{
    public class AccountModel
    {
        public Choom Choom { get; init; }

        public List<Order> Orders { get; set; }

        public void InitOrdersManually(DDSDataContext context)
        {
            if (Choom != null)
            {
                var orders = context.Orders.Where(o => o.ChoomId == Choom.Id).ToList();
                Orders = orders;
            }
        }
    }
}
