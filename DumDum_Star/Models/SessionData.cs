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
                return "~/images/light/header/basket/basket-new.png";

            else
                return "~/images/light/header/basket/basket.png";
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

            ValidateOrderState();
            return toReturn;
        }

        public static bool UpdateCyberWareInOrder(int cyberWareId, int newCount)
        {
            if (CurrentOrder != null)
            {
                var cyber = CurrentOrder.CyberWareToOrders.FirstOrDefault(cyb => cyb.CyberWareId == cyberWareId);
                if (cyber != null)
                {
                    cyber.Count = newCount;
                    ValidateOrderState();

                    return true;
                }
            }

            return false;
        }

        public static bool RemoveCyberWareFromOrder(CyberWare? cyberWare)
        {
            bool toReturn = false;
            if (CurrentChoom != null && CurrentOrder != null)
            {
                var toDelete = CurrentOrder.CyberWareToOrders.FirstOrDefault(cyb => cyb.CyberWareId == cyberWare?.Id);
                if (toDelete != null)
                    toReturn = CurrentOrder.CyberWareToOrders.Remove(toDelete);
            }

            return toReturn;
        }

        public static void ResetChoom()
        {
            CurrentChoom = null;
            ResetOrder();
        }

        public static void ResetOrder()
        {
            CurrentOrder = null;
        }

        private static void ValidateOrderState()
        {
            for (int i = 0; i < CurrentOrder.CyberWareToOrders.Count; i++)
            {
                var current = CurrentOrder.CyberWareToOrders.ElementAt(i);
                if (current.Count < 1)
                    RemoveCyberWareFromOrder(current.CyberWare);
            }
        }

        #region Cloning Functions.

        public static Choom? CloneChoom()
        {
            if (CurrentChoom != null)
            {
                var clone = new Choom()
                {
                    Id = CurrentChoom.Id,
                    Name = CurrentChoom.Name,
                    Login = CurrentChoom.Login,
                    Password = CurrentChoom.Password,
                    MailAddress = CurrentChoom.MailAddress
                };

                return clone;
            }

            return null;
        }

        public static Order? CloneOrder(Choom parent)
        {
            if (CurrentOrder != null)
            {
                var order = new Order()
                {
                    Id = 0,
                    ChoomId = parent.Id,
                    ChippinTime = CurrentOrder.ChippinTime,
                    AddressId = CurrentOrder.AddressId,
                    Address = CurrentOrder.Address,
                    CyberWareToOrders = CloneCyberWareToOrders()
                };

                return order;
            }

            return null;
        }

        private static ICollection<CyberWareToOrder> CloneCyberWareToOrders()
        {
            if (CurrentOrder != null)
            {
                var toReturn = new List<CyberWareToOrder>(CurrentOrder.CyberWareToOrders.Count);
                foreach (var cwto in CurrentOrder.CyberWareToOrders)
                {
                    toReturn.Add(new CyberWareToOrder()
                    {
                        Id = cwto.Id,
                        CyberWareId = cwto.CyberWareId,
                        OrderId = cwto.OrderId,
                        Count = cwto.Count
                    });
                }

                return toReturn;
            }

            throw new NullReferenceException();
        }
        #endregion
    }
}
