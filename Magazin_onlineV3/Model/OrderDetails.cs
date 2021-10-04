using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_onlineV3.Model
{
    public class OrderDetails : IComparable<OrderDetails>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public OrderDetails(int id, int orderid, int productId, double price,  int quantity)
        {
            this.Id = id;
            this.OrderId = orderid;
            this.ProductId = productId;
            this.Price = price;
            this.Quantity = quantity;
        }
        public OrderDetails(String details) : this(int.Parse(details.Split(',')[0]), int.Parse(details.Split(',')[1]), int.Parse(details.Split(',')[2]), double.Parse(details.Split(',')[3]), int.Parse(details.Split(',')[4]))
        {

        }

        public override string ToString()
        {
            String text = "";
            text += Id + ",";
            text += OrderId + ",";
            text += ProductId + ",";
            text += Price + ",";
            text += Quantity;
            return text;
        }

        public override bool Equals(object obj)
        {
            if(obj is OrderDetails)
            {
                OrderDetails order = obj as OrderDetails;
                if (this.Id == order.Id)
                    return true;
            }
            return false;
        }

        public int CompareTo(OrderDetails other)
        {
            throw new NotImplementedException();
        }
    }
}
