using Magazin_onlineV3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.Controlere
{
    class ControlOrders 
    {
        public Lista<Orders> orders;

        public ControlOrders()
        {
            orders = new Lista<Orders>();
            open();
        }

        public void add(Orders order)
        {
            Node<Orders> node = orders.getLast();
            order.Id = node.Data.Id + 1;
            orders.addFinish(order);
        }

        public void delete(Orders order)
        {
            orders.remove(order);
        }

        public void open()
        {
            orders.reset();
            String path = Application.StartupPath;
            StreamReader reader = new StreamReader(path + @"\orders.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                orders.addFinish(new Orders(linie));
            }
            reader.Close();
        }

        public void save()
        {
            String path = Application.StartupPath;
            StreamWriter writer = new StreamWriter(path + @"\orders.txt");
            writer.Write(this.ToString());
            writer.Close();
        }

        public override string ToString()
        {
            Node<Orders> iterator = orders.getIterator();
            String text = "";
            while (iterator != null)
            {
                text += iterator.Data.ToString() + Environment.NewLine;
                iterator = iterator.Next;
            }
            return text;
        }

        public Orders currentCart(int customerId)
        {
            Node<Orders> node = orders.getIterator();
            for (int i = 0; i < orders.size(); i++)
            {
                if (node.Data.CostomerId.Equals(customerId) && node.Data.Comandat == false)
                    return node.Data;
                node = node.Next;
            }
            return null;
        }

        public Lista<Orders> istoricOrders(int customerId)
        {
            Lista<Orders> order = new Lista<Orders>();
            Node<Orders> node = orders.getIterator();
            for (int i = 0; i < orders.size(); i++)
            {
                if (node.Data.CostomerId.Equals(customerId) && node.Data.Comandat == true)
                    order.addFinish(node.Data);
                node = node.Next;
            }
            if (order.size() == 0)
                return null;
            return order;
        }
    }
}
