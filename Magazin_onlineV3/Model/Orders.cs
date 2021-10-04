using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_onlineV3.Model
{
    class Orders : IComparable<Orders>
    {
        public int Id { get; set; }
        public int CostomerId { get; set; }
        public DateTime Date { get; set; }
        public bool Comandat { get; set; }

        public Orders(int id, int costomerId, DateTime date, bool comandat)
        {
            this.Id = id;
            this.CostomerId = costomerId;
            this.Date = date;
            this.Comandat = comandat;
        }
        public Orders(String order) : this(int.Parse(order.Split(',')[0]), int.Parse(order.Split(',')[1]), DateTime.Parse(order.Split(',')[2]), bool.Parse(order.Split(',')[3]))
        {

        }

        public override string ToString()
        {
            String text = "";
            text += Id + ",";
            text += CostomerId + ",";
            text += Date.ToString("d") + ",";
            text += Comandat;
            return text;
        }

        public override bool Equals(object obj)
        {
            if(obj is Orders)
            {
                Orders orders = obj as Orders;
                if (this.Id == orders.Id)
                    return true;
            }
            return false;
        }

        public int CompareTo(Orders other)
        {
            return this.Date.CompareTo(other);
        }
    }
}
