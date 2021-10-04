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
    class OldOrderCard : Panel
    {
        private OrderDetails details;
        private Produs produs;

        public OldOrderCard(OrderDetails details, Produs produs)
        {
            this.details = details;
            this.produs = produs;

            layout();
        }

        public void layout()
        {
            this.Size = new Size(560, 40);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

            setImagine();
            setNume();
            setCantitate();
            setPret();
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

            this.Controls.Add(lblNume);
        }

        public void setCantitate()
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(410, 10);
            textBox.Size = new Size(30, 30);
            textBox.Text = details.Quantity.ToString();
            textBox.Name = "txtCantitate";
            textBox.ReadOnly = true;
            this.Controls.Add(textBox);
        }

        public void setPret()
        {
            Label label = new Label();
            label.Size = new Size(100, 30);
            label.Location = new Point(450, 5);
            label.Name = "lblPret";
            label.Text = details.Price.ToString() + " lei";

            label.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(label);
        }

    }
}
