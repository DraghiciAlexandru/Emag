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
    class ControlOrderDetails
    {
        public Lista<OrderDetails> details;

        public ControlOrderDetails()
        {
            details = new Lista<OrderDetails>();
            open();
        }

        public void add(OrderDetails order)
        {
            Node<OrderDetails> node = details.getLast();
            order.Id = node.Data.Id + 1;
            details.addFinish(order);
        }

        public void delete(OrderDetails order)
        {
            details.remove(order);
        }

        public void open()
        {
            details.reset();
            String path = Application.StartupPath;
            StreamReader reader = new StreamReader(path + @"\details.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                details.addFinish(new OrderDetails(linie));
            }
            reader.Close();
        }

        public void save()
        {
            String path = Application.StartupPath;
            StreamWriter writer = new StreamWriter(path + @"\details.txt");
            writer.Write(this.ToString());
            writer.Close();
        }

        public override string ToString()
        {
            Node<OrderDetails> iterator = details.getIterator();
            String text = "";
            while (iterator != null)
            {
                text += iterator.Data.ToString() + Environment.NewLine;
                iterator = iterator.Next;
            }
            return text;
        }

        public Lista<OrderDetails> getDetails(int orderId)
        {
            Lista<OrderDetails> cart = new Lista<OrderDetails>();
            Node<OrderDetails> node = details.getIterator();
            for (int i = 0; i < details.size(); i++) 
            {
                if (node.Data.OrderId == orderId) 
                    cart.addFinish(node.Data);
                node = node.Next;
            }
            return cart;
        }

        public bool inCart(int orderId, int idProdus)
        {
            Lista<OrderDetails> lista = getDetails(orderId);
            Node<OrderDetails> node = lista.getIterator();
            for(int i=0; i<lista.size(); i++)
            {
                if (node.Data.ProductId == idProdus)
                    return true;
                node = node.Next;
            }
            return false;
        }

        public void addCantitate(int orderId, int idProdus, double pretProdus)
        {
            Lista<OrderDetails> lista = getDetails(orderId);
            Node<OrderDetails> node = lista.getIterator();
            for (int i = 0; i < lista.size(); i++)
            {
                if (node.Data.ProductId == idProdus)
                {
                    node.Data.Quantity += 1;
                    node.Data.Price = pretProdus * node.Data.Quantity;
                }
                node = node.Next;
            }
        }

        public double sumaCart(Lista<OrderDetails> lista)
        {
            Node<OrderDetails> node = lista.getIterator();
            double suma = 0;
            for (int i = 0; i < lista.size(); i++)
            {
                suma += node.Data.Price;
                node = node.Next;
            }
            return suma;
        }
    }
}
