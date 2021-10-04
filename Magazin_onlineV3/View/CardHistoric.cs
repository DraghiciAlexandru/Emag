using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Magazin_onlineV3.Model;
using Magazin_onlineV3.Controlere;

namespace Magazin_onlineV3.View
{
    class CardHistoric : Panel
    {
        private Orders orders;
        private ControlOrderDetails orderDetails;
        private ControlProdus controlProdus;
        int x = 10, y = 30;

        public CardHistoric(Orders orders)
        {
            this.orders = orders;
            orderDetails = new ControlOrderDetails();
            controlProdus = new ControlProdus();
            this.BorderStyle = BorderStyle.None;
            this.Paint += CardHistoric_Paint;

            layout();
        }

        private void CardHistoric_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        public void layout()
        {
            this.Size = new Size(600, 100);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.AutoScroll = true;
            setId();
            setDate();
            setDetails();
            setTotal();
        }

        public void setId()
        {
            Label lblId = new Label();
            lblId.Text = "Id comanda: " + orders.Id;
            lblId.AutoSize = false;
            lblId.Size = new Size(100, 20);
            lblId.Location = new Point(10, 5);
            lblId.Name = "lblId";
            lblId.ForeColor = Color.FromArgb(255, 255, 255, 255);
            lblId.Font = new Font("Microsoft Sitka Small", 9, FontStyle.Regular);

            Controls.Add(lblId);
        }

        public void setDate()
        {
            Label lblData = new Label();
            lblData.Text = "Date: " + orders.Date.ToString("d");
            lblData.AutoSize = false;
            lblData.Size = new Size(120, 20);
            lblData.Location = new Point(150, 5);
            lblData.Name = "lblData";
            lblData.ForeColor = Color.FromArgb(255, 255, 255, 255);
            lblData.Font = new Font("Microsoft Sitka Small", 9, FontStyle.Regular);

            Controls.Add(lblData);
        }

        public void setDetails()
        {
            Lista<OrderDetails> list = orderDetails.getDetails(orders.Id);
            Node<OrderDetails> node = list.getIterator();
            for (int i = 0; i < list.size(); i++) 
            {
                Panel panel = new OldOrderCard(node.Data, controlProdus.getProdus(node.Data.ProductId));
                panel.Location = new Point(x, y);
                y += 45;
                Controls.Add(panel);
                node = node.Next;
            }
        }

        public void setTotal()
        {
            Label lblTotal = new Label();
            lblTotal.Text = "Total: " + orderDetails.sumaCart(orderDetails.getDetails(orders.Id));
            lblTotal.AutoSize = false;
            lblTotal.Size = new Size(120, 20);
            lblTotal.Location = new Point(450, 5);
            lblTotal.Name = "lblTotal";
            lblTotal.ForeColor = Color.FromArgb(255, 255, 255, 255);
            lblTotal.Font = new Font("Microsoft Sitka Small", 9, FontStyle.Regular);

            Controls.Add(lblTotal);
        }
    }
}
