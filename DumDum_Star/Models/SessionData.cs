using DumDum_Star.Models.Entities;

namespace DumDum_Star.Models
{
    public class SessionData
    {
        public static Choom? CurrentChoom { get; set; }

        public static Order? CurrentOrder { get; private set; }

        public static string GetHeaderText()
        {
            if (CurrentChoom == null)
                return "Гость";

            return CurrentChoom.Login;
        }

        public static string GetBasketIconPath()
        {
            if (CurrentOrder?.CyberWareToOrders.Any() ?? false)
                return "~/icons/light/header/basket/basket-new.png";

            else
                return "~/icons/light/header/basket/basket.png";
        }

        public static bool InsertCyberWareToOrder(CyberWare? cyberWare, int count)
        {
            bool toReturn = false;
            if (CurrentChoom != null && cyberWare != null)
            {
                if (CurrentOrder == null)
                {
                    CurrentOrder = new Order()
                    {
                        ChoomId = CurrentChoom.Id,
                        Choom = CurrentChoom,
                        CyberWareToOrders = new List<CyberWareToOrder>(1)
                    };

                    toReturn = true;
                }

                if (CurrentOrder.CyberWareToOrders.FirstOrDefault(cyb => cyb.CyberWareId == cyberWare.Id) is var cyberWareOrder &&
                    cyberWareOrder != null)
                {
                    cyberWareOrder.Count = count != 1 ? count :
                                           cyberWareOrder.Count + 1;
                }
                else
                {
                    CurrentOrder.CyberWareToOrders.Add(new()
                    {
                        Count = count,
                        CyberWareId = cyberWare.Id,
                        CyberWare = cyberWare,
                        OrderId = CurrentOrder.Id,
                        Order = CurrentOrder
                    });
                }
            }

            return toReturn;
        }

        public static bool RemoveCyberWareFromOrder(CyberWare? cyberWare)
        {
            bool toReturn = false;
            if (CurrentChoom != null && CurrentOrder != null)
            {
                var toDelete = CurrentOrder.CyberWareToOrders.FirstOrDefault(cyb => cyb.Id == cyberWare?.Id);
                if (toDelete != null)
                    toReturn = CurrentOrder.CyberWareToOrders.Remove(toDelete);
            }

            return toReturn;
        }
    }
}
