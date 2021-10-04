using Magazin_onlineV3.Controlere;
using Magazin_onlineV3.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.View
{
    public class OrderCard : Panel
    {
        private ControlOrders controlOrders;
        private ControlOrderDetails orderDetails;
        private ControlPersoane controlPersoane;
        private ControlProdus controlProdus;
        private OrderDetails details;
        private Produs produs;
        private Panel Main;

        public OrderCard(OrderDetails details, Produs produs, Panel main)
        {
            this.details = details;
            this.produs = produs;
            controlOrders = new ControlOrders();
            orderDetails = new ControlOrderDetails();
            controlPersoane = new ControlPersoane();
            controlProdus = new ControlProdus();
            this.Main = main;

            layout();
        }

        public void layout()
        {
            this.Size = new Size(600, 40);
            this.BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
            setImagine();
            setNume();
            setCantitate();
            setPlusMinus();
            setPret();
            setDelete();
        }

        public void setImagine()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(30, 30);
            pictureBox.Location = new Point(10, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.BackgroundImage = Image.FromFile(produs.PathImage);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pictureBox);
        }

        public void setNume()
        {
            Label lblNume = new Label();
            lblNume.Size = new Size(350, 30);
            lblNume.Location = new Point(50, 5);
            lblNume.Name = "lblNume";
            lblNume.Text = produs.Nume;
            lblNume.TextAlign = ContentAlignment.MiddleLeft;
            lblNume.Font = new Font("Microsoft Sitka Small", 10, FontStyle.Regular);

            this.Controls.Add(lblNume);
        }

        public void setCantitate()
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(410, 10);
            textBox.Size = new Size(30, 30);
            textBox.Text = details.Quantity.ToString();
            textBox.Name = "txtCantitate";

            textBox.TextChanged += TextBox_TextChanged;

            this.Controls.Add(textBox);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox text = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtCantitate")
                    text = x as TextBox;
            }
            int p;
            if (int.TryParse(text.Text, out p))
            {
                Lista<OrderDetails> detali = orderDetails.details;
                Node<OrderDetails> node1 = detali.getIterator();
                for (int i = 0; i < detali.size(); i++)
                {
                    if (node1.Data.Id == details.Id)
                    {
                        node1.Data.Quantity = int.Parse(text.Text);
                        node1.Data.Price = controlProdus.getProdus(details.ProductId).Pret * node1.Data.Quantity;
                        details = node1.Data;
                    }
                    node1 = node1.Next;
                }
                orderDetails.save();
                Main.Controls.Clear();
                Orders current = controlOrders.currentCart(controlPersoane.getLoged().Id);
                if (current != null)
                {
                    Lista<OrderDetails> orders = orderDetails.getDetails(current.Id);
                    int x = 30, y = 15;
                    Node<OrderDetails> node = orders.getIterator();
                    for (int i = 0; i < orders.size(); i++)
                    {
                        Panel panel = new Panel();
                        panel = new OrderCard(node.Data, controlProdus.getProdus(node.Data.ProductId), Main);
                        panel.Location = new Point(x, y);
                        y += 45;
                        node = node.Next;
                        Main.Controls.Add(panel);
                    }
                    setTotal(Main, x, y, orders);
                    setComanda(Main, x, y);
                }
                else
                {
                    setGol(Main);
                }
            }
            else
            {
                details.Quantity = 1;
            }
        }

        public void setPlusMinus()
        {
            String path = Application.StartupPath;
            Button plus = new Button();
            plus.Size = new Size(14, 14);
            plus.Location = new Point(445, 4);
            plus.Name = "btnPlus";

            plus.BackgroundImage = Image.FromFile(path + @"\resources\arrow_up.png");
            plus.BackgroundImageLayout = ImageLayout.Stretch;

            plus.Click += Plus_Click;

            Button minus = new Button();
            minus.Size = new Size(14, 14);
            minus.Location = new Point(445, 20);
            minus.Name = "btnMinus";

            minus.BackgroundImage = Image.FromFile(path + @"\resources\arrow_down.png");
            minus.BackgroundImageLayout = ImageLayout.Stretch;

            minus.Click += Minus_Click;

            this.Controls.Add(plus);
            this.Controls.Add(minus);
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            TextBox text = new TextBox();
            foreach(Control x in Controls) 
            {
                if (x.Name == "txtCantitate")
                    text = x as TextBox;
            }

            int cantitate = int.Parse(text.Text);
            if (cantitate > 1)
            {
                cantitate--;
                text.Text = cantitate.ToString();
            }
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            TextBox text = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtCantitate")
                    text = x as TextBox;
            }

            int cantitate = int.Parse(text.Text);
            cantitate++;
            text.Text = cantitate.ToString();
        }

        public void setPret()
        {
            Label label = new Label();
            label.Size = new Size(100, 30);
            label.Location = new Point(465, 4);
            label.Name = "lblPret";
            label.Text = details.Price.ToString() + " lei";

            label.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(label);
        }

        public void setDelete()
        {
            String path = Application.StartupPath;
            Button btnDelete = new Button();
            btnDelete.Size = new Size(24, 24);
            btnDelete.Location = new Point(570, 7);
            btnDelete.Name = "btnDelete";
            btnDelete.BackgroundImage= Image.FromFile(path+ @"\resources\trash.png");
            btnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            btnDelete.Click += BtnDelete_Click;

            Controls.Add(btnDelete);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            orderDetails.delete(details);
            orderDetails.save();
            Main.Controls.Clear();
            Orders current = controlOrders.currentCart(controlPersoane.getLoged().Id);
            if (current != null)
            {
                Lista<OrderDetails> orders = orderDetails.getDetails(current.Id);
                int x = 30, y = 15;
                Node<OrderDetails> node = orders.getIterator();
                for (int i = 0; i < orders.size(); i++)
                {
                    Panel panel = new Panel();
                    panel = new OrderCard(node.Data, controlProdus.getProdus(node.Data.ProductId), Main);
                    panel.Location = new Point(x, y);
                    y += 45;
                    node = node.Next;
                    Main.Controls.Add(panel);
                }
                setTotal(Main, x, y, orders);
                setComanda(Main, x, y);
            }
            else
            {
                setGol(Main);
            }
        }

        public void setGol(Panel main)
        {
            main.Controls.Clear();
            Label gol = new Label();
            gol.Text = "Cosul dumneavostra este gol!";
            gol.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            gol.Location = new Point(180, 100);
            gol.AutoSize = false;
            gol.Size = new Size(300, 60);
            main.Controls.Add(gol);
        }

        public void setTotal(Panel main, int x, int y, Lista<OrderDetails> cart)
        {
            Label label = new Label();
            label.Text = "Total:";
            label.Location = new Point(455, y + 15);
            label.AutoSize = true;
            main.Controls.Add(label);

            Label lblTotal = new Label();
            lblTotal.Location = new Point(496, y + 15);
            lblTotal.Text = orderDetails.sumaCart(cart).ToString() + " lei";
            lblTotal.AutoSize = false;
            lblTotal.Size = new Size(100, 40);
            lblTotal.Name = "lblTotal";
            lblTotal.TextAlign = ContentAlignment.TopCenter;
            main.Controls.Add(lblTotal);
        }

        public void setComanda(Panel main, int x, int y)
        {
            Button btnConfirma = new Button();
            btnConfirma.Size = new Size(100, 25);
            btnConfirma.Location = new Point(30, y + 5);
            btnConfirma.Text = "Comanda";
            btnConfirma.Name = "btnConfirma";

            btnConfirma.Click += BtnConfirma_Click;

            Main.Controls.Add(btnConfirma);
        }

        private void BtnConfirma_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Orders order = controlOrders.currentCart(controlPersoane.getLoged().Id);

            order.Date = DateTime.Today;
            order.Comandat = true;

            controlOrders.save();

            Main.Controls.Clear();

            setGol(Main);
        }
    }
}
