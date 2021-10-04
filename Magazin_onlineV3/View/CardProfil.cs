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
    class CardProfil : Panel
    {
        private ControlPersoane controlPersoane;
        private Client client;

        public CardProfil(Client client)
        {
            this.client = client;
            controlPersoane = new ControlPersoane();
            layout();
        }

        public void layout()
        {
            this.Size = new Size(600, 150);
            this.BorderStyle = BorderStyle.FixedSingle;

            setPicture();
            setName();
            setEmail();
            setAdresa();
            setTel();
            setEdit();
        }

        public void setPicture()
        {
            PictureBox picture = new PictureBox();
            picture.Size = new Size(100, 100);
            picture.Location = new Point(10, 25);

            picture.BackgroundImage = Image.FromFile(@"D:\C#\UI design\Dinamic\Magazin_onlineV3\Magazin_onlineV3\bin\Debug\resources\account.png");

            picture.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(picture);
        }

        public void setName()
        {
            TextBox txtNume = new TextBox();
            txtNume.Text = "Nume: " + client.Username;
            txtNume.Size = new Size(200, 40);
            txtNume.Location = new Point(130, 30);
            txtNume.Name = "txtNume";
            txtNume.ReadOnly = true;
            txtNume.Multiline = true;

            Font = new Font("Microsoft Sitka Small", 8, FontStyle.Regular);

            txtNume.TextChanged += TxtNume_TextChanged;

            this.Controls.Add(txtNume);
        }

        private void TxtNume_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (!text.Text.Contains("Nume:"))
            {
                Node<Persoana> node = controlPersoane.persoane.getElement(client);
                client.Username = text.Text;
                node.Data.Username = text.Text;
                controlPersoane.saveClienti();
            }
        }

        public void setEmail()
        {
            TextBox txtEmail = new TextBox();
            txtEmail.Text = "Email: " + client.Email;
            txtEmail.Size = new Size(200, 40);
            txtEmail.Location = new Point(350, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Multiline = true;

            Font = new Font("Microsoft Sitka Small", 8, FontStyle.Regular);

            txtEmail.TextChanged += TxtEmail_TextChanged;

            this.Controls.Add(txtEmail);
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (!text.Text.Contains(":")) 
            {
                Node<Client> node = controlPersoane.clienti.getElement(client);
                
                client.Email = text.Text;
                node.Data.Email = text.Text;
                controlPersoane.saveClienti();
            }
        }

        public void setAdresa()
        {
            TextBox txtAdresa = new TextBox();
            txtAdresa.Text = "Adresa: " + client.Adresa;
            txtAdresa.Size = new Size(200, 40);
            txtAdresa.Location = new Point(130, 85);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.ReadOnly = true;
            txtAdresa.Multiline = true;

            Font = new Font("Microsoft Sitka Small", 8, FontStyle.Regular);

            txtAdresa.TextChanged += TxtAdresa_TextChanged;

            this.Controls.Add(txtAdresa);
        }

        private void TxtAdresa_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (!text.Text.Contains("Adresa:"))
            {
                Node<Client> node = controlPersoane.clienti.getElement(client);

                client.Adresa = text.Text;
                node.Data.Adresa = text.Text;
                controlPersoane.saveClienti();
            }
        }

        public void setTel()
        {
            TextBox txtPhone = new TextBox();
            txtPhone.Text = "Telefon: " + client.Phone;
            txtPhone.Size = new Size(200, 40);
            txtPhone.Location = new Point(350, 85);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Multiline = true;

            Font = new Font("Microsoft Sitka Small", 8, FontStyle.Regular);

            txtPhone.TextChanged += TxtPhone_TextChanged;

            this.Controls.Add(txtPhone);
        }

        private void TxtPhone_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (!text.Text.Contains("Telefon:"))
            {
                Node<Client> node = controlPersoane.clienti.getElement(client);

                client.Phone = text.Text;
                node.Data.Phone = text.Text;
                controlPersoane.saveClienti();
            }
        }

        public void setEdit()
        {
            String path = Application.StartupPath;
            Button btnEdit = new Button();
            btnEdit.Size = new Size(40, 40);
            btnEdit.Location = new Point(555, 3);
            btnEdit.Name = "btnEdit";

            btnEdit.Click += BtnEdit_Click;

            btnEdit.BackgroundImage = Image.FromFile(path + @"\resources\edit.png");
            btnEdit.BackgroundImageLayout = ImageLayout.Stretch;
            btnEdit.BackColor = Color.FromArgb(40, 40, 40);
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;

            this.Controls.Add(btnEdit);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TextBox txtNume = new TextBox();
            TextBox txtEmail = new TextBox();
            TextBox txtAdresa = new TextBox();
            TextBox txtTel = new TextBox();

            foreach(Control x in Controls)
            {
                if (x.Name == "txtNume")
                    txtNume = x as TextBox;
                if (x.Name == "txtEmail")
                    txtEmail = x as TextBox;
                if (x.Name == "txtAdresa")
                    txtAdresa = x as TextBox;
                if (x.Name == "txtPhone")
                    txtTel = x as TextBox;
            }

            if (txtNume.ReadOnly == true)
            {
                txtNume.Text = client.Username;
                txtEmail.Text = client.Email;
                txtAdresa.Text = client.Adresa;
                txtTel.Text = client.Phone;
                txtNume.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtAdresa.ReadOnly = false;
                txtTel.ReadOnly = false;
            }
            else
            {
                txtNume.Text = "Nume: " + txtNume.Text;
                txtEmail.Text = "Email: " + txtEmail.Text;
                txtAdresa.Text = "Adresa: " + txtAdresa.Text;
                txtTel.Text = "Telefon: " + txtTel.Text;
                txtNume.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtAdresa.ReadOnly = true;
                txtTel.ReadOnly = true;
            }
        }
    }
}
