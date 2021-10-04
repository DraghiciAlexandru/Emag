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
    public class Card : Panel
    {
        private Produs produs;

        private ControlOrders controlOrders;
        private ControlOrderDetails orderDetails;
        private ControlPersoane controlPersoane;

        public Produs Produs
        {
            get { return produs; }
        }

        public Card(Produs produs)
        {
            this.produs = produs;
            controlPersoane = new ControlPersoane();
            controlOrders = new ControlOrders();
            orderDetails = new ControlOrderDetails();
            layout();
        }

        public void layout()
        {
            Size = new Size(150, 200);
            BorderStyle = BorderStyle.Fixed3D;
            BackColor = Color.FromArgb(255, 255, 255, 255);
            setImage();
            setNume();
            setPret();
            setButon();
        }

        public void setImage()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(110, 110);
            pictureBox.Location = new Point(20, 10);
            pictureBox.BackgroundImage = Image.FromFile(produs.PathImage);
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(pictureBox);
        }

        public void setNume()
        {
            Label lblNume = new Label();
            lblNume.Size = new Size(130, 15);
            lblNume.Text = produs.Nume;
            lblNume.Location = new Point(10, 130);
            lblNume.TextAlign = ContentAlignment.TopCenter;
            lblNume.Font = new Font("Microsoft Sitka Small", 9, FontStyle.Regular);
            Controls.Add(lblNume);
        }

        public void setPret()
        {
            Label lblPret = new Label();
            lblPret.Size = new Size(100, 20);
            lblPret.Font = new Font("Microsoft Sitka Small", 12, FontStyle.Regular);
            lblPret.Text = produs.Pret.ToString() + " lei";
            lblPret.Location = new Point(25, 145);
            lblPret.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(lblPret);
        }

        public void setButon()
        {
            RoundButton btnAdd = new RoundButton();
            btnAdd.Size = new Size(100, 30);
            btnAdd.Location = new Point(25, 165);
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.BackColor = Color.Gray;
            btnAdd.Text = "Comanda";
            btnAdd.Name = produs.Id.ToString();
            btnAdd.Click += BtnAdd_Click;

            btnAdd.BackColor = Color.FromArgb(255, 255, 255, 255);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.ButtonColor = Color.FromArgb(30, 119, 216);
            btnAdd.OnHoverButtonColor = Color.Blue;
            btnAdd.OnHoverBorderColor = Color.Black;
            btnAdd.OnHoverTextColor = Color.Black;

            Controls.Add(btnAdd);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(controlPersoane.Loged==false)
            {
                MessageBox.Show("Please login!", "Login required!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (controlOrders.currentCart(controlPersoane.getLoged().Id) != null) 
                {
                    if (orderDetails.inCart(controlOrders.currentCart(controlPersoane.getLoged().Id).Id, produs.Id) == false) 
                    {
                        orderDetails.add(new OrderDetails(0, controlOrders.currentCart(controlPersoane.getLoged().Id).Id, produs.Id, produs.Pret, 1));
                        orderDetails.save();
                    }
                    else
                    {
                        orderDetails.addCantitate(controlOrders.currentCart(controlPersoane.getLoged().Id).Id, produs.Id, produs.Pret);
                        orderDetails.save();
                    }
                }
                else
                {
                    controlOrders.add(new Orders(0, controlPersoane.getLoged().Id, DateTime.Today, false));
                    controlOrders.save();
                    orderDetails.add(new OrderDetails(0, controlOrders.currentCart(controlPersoane.getLoged().Id).Id, produs.Id, produs.Pret, 1));
                    orderDetails.save();
                }
            }
        }
    }
}
