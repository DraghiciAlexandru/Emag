using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Magazin_onlineV3.Controlere;
using Magazin_onlineV3.Model;

namespace Magazin_onlineV3.View
{
    class ViewHome : ViewMagazin
    {
        Panel Aside;
        Panel Main;
        Panel Produse;

        ControlProdus control;
        ControlPersoane controlPersoane;
        ControlOrders controlOrders;
        ControlOrderDetails controlOrderDetails;

        public ViewHome() : base()
        {
            control = new ControlProdus();
            controlPersoane = new ControlPersoane();
            controlOrders = new ControlOrders();
            controlOrderDetails = new ControlOrderDetails();
            Aside = new Panel();
            Main = new Panel();
            Produse = new Panel();
            layout();
        }

        public void layout()
        {
            base.layout();
            setAside(Aside);
            setMain(Main);
            setSortare(Main);
            setProduse(Produse);
            setCard(Produse, control.Lista);
            setProfil(Header);
            setHome(Header);
        }

        public void setHome(Panel header)
        {
            String path = Application.StartupPath;
            Button btnHome = new Button();
            btnHome.Name = "btnHome";
            btnHome.Location = new Point(10, 5);
            btnHome.Size = new Size(150, 40);

            btnHome.Click += BtnHome_Click;

            btnHome.BackgroundImage = Image.FromFile(path + @"\resources\Icon.png");
            btnHome.BackgroundImageLayout = ImageLayout.Stretch;
            btnHome.BackColor = Color.FromArgb(40, 40, 40);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;

            header.Controls.Add(btnHome);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Aside.Controls.Clear();
            Main.Controls.Clear();
            Controls.Clear();
            layout();
        }

        public override void setAside(Panel aside)
        {
            String path = Application.StartupPath;
            aside.Location = new Point(0, 50);
            aside.Size = new Size(130, 350);
            aside.BorderStyle = BorderStyle.FixedSingle;
            aside.BackColor = Color.FromArgb(40, 40, 40);

            Price price = new Price();
            price.Name = "pnlPrice";
            aside.Controls.Add(price);

            Button button = new Button();
            button.Size = new Size(50, 25);
            button.Location = new Point(40, 180);
            button.Click += Button_Click;
            button.BackgroundImage= Image.FromFile(path + @"\resources\checkmark.png");
            button.BackgroundImageLayout = ImageLayout.Center;
            aside.Controls.Add(button);

            Controls.Add(aside);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            setCard(Produse, control.produseFiltrate(Aside));
        }

        public override void setMain(Panel main)
        {
            main.Location = new Point(130, 50);
            main.Size = new Size(660, 350);
            main.BorderStyle = BorderStyle.FixedSingle;
            main.BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(main);
        }

        public void setProduse(Panel produse)
        {
            produse.Location = new Point(0, 40);
            produse.Size = new Size(660, 310);
            produse.BorderStyle = BorderStyle.FixedSingle;
            produse.AutoScroll = true;
            Main.Controls.Add(produse);
        }

        public void setCard(Panel produse, Lista<Produs> lista)
        {
            produse.Controls.Clear();
            Point point = new Point(6, 6);
            Node<Produs> node = lista.getIterator();
            for (int i = 0; i < lista.size(); i++)
            {
                Card card = new Card(node.Data);
                card.Location = point;
                point = new Point(point.X + 158, point.Y);
                if (i % 3 == 0 && i != 0)
                    point = new Point(6, point.Y + 206);
                node = node.Next;
                produse.Controls.Add(card);
            }
        }

        public void setSortare(Panel main)
        {
            Panel sortare = new Panel();
            sortare.Location = new Point(0, 0);
            sortare.Size = new Size(main.Width, 40);
            sortare.BorderStyle = BorderStyle.FixedSingle;
            sortare.Name = "pnlSortare";

            ComboBox box = new ComboBox();
            box.Size = new Size(130, 20);
            box.Location = new Point(10, 15);
            box.Name = "cboSortare";
            box.Text = "Ordeoneaza dupa:";
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            box.BackColor = Color.FromArgb(40, 40, 40);
            box.Font = new Font("Microsoft Sitka Small", 8, FontStyle.Regular);
            box.ForeColor = Color.White;

            box.Items.Add("Pret crescator");
            box.Items.Add("Pret descrescator");

            TextBox text = new TextBox();
            text.Size = new Size(90, 20);
            text.Location = new Point(10, 2);
            text.Text = "Ordeoneaza dupa:";
            text.BorderStyle = BorderStyle.None;
            text.BackColor = Color.FromArgb(40, 40, 40);
            text.Font = new Font("Microsoft Sitka Small", 8, FontStyle.Regular);
            text.ForeColor = Color.White;

            box.SelectedValueChanged += Box_SelectedValueChanged;

            sortare.Controls.Add(text);
            sortare.Controls.Add(box);

            main.Controls.Add(sortare);
        }

        private void Box_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox box = sender as ComboBox;
            if (box.SelectedIndex == 0)
            {
                control.Lista.sort(1);
                setCard(Produse, control.Lista);
            }
            else
            {
                control.Lista.sort(-1);
                setCard(Produse, control.Lista);
            }
        }

        private void setProfil(Panel header)
        {
            String path = Application.StartupPath;
            Button btnProfil = new Button();
            btnProfil.Size = new Size(40, 40);
            btnProfil.Location = new Point(690, 5);
            btnProfil.Text = "";
            btnProfil.Name = "btnProfil";

            btnProfil.BackgroundImage = Image.FromFile(path + @"\resources\user.png");
            btnProfil.BackgroundImageLayout = ImageLayout.Stretch;
            btnProfil.BackColor = Color.FromArgb(40, 40, 40);
            btnProfil.FlatAppearance.BorderSize = 0;
            btnProfil.FlatStyle = FlatStyle.Flat;

            btnProfil.Click += BtnProfil_Click;

            header.Controls.Add(btnProfil);
        }

        private void BtnProfil_Click(object sender, EventArgs e)
        {
            if (controlPersoane.Loged == false)
                setLogin();
            else
            {
                controlOrders.open();
                controlOrderDetails.open();
                layoutClient();
            }
        }

        private void setLogin()
        {
            Aside.Size = new Size(0, 0);
            Main.Size = new Size(0, 0);
            this.BackColor = Color.FromArgb(40, 40, 40);
            setImgProf();
            setUsername();
            setPassword();
            setBtnLogin();
        }

        public void setImgProf()
        {
            String path = Application.StartupPath;
            PictureBox box = new PictureBox();
            box.Size = new Size(100, 100);
            box.BorderStyle = BorderStyle.None;
            box.Location = new Point(345, 110);
            box.BackgroundImage = Image.FromFile(path + @"\resources\lock.png");
            Controls.Add(box);
        }

        public void setUsername()
        {
            TextBox box = new TextBox();
            box.Size = new Size(200, 25);
            box.Location = new Point(295, 230);
            box.Name = "txtUser";

            Controls.Add(box);
        }

        public void setPassword()
        {
            TextBox box = new TextBox();
            box.Size = new Size(200, 25);
            box.Location = new Point(295, 270);
            box.Name = "txtPassword";
            box.PasswordChar = '●';

            Controls.Add(box);
        }

        public void setBtnLogin()
        {
            RoundButton btnLogin = new RoundButton();
            btnLogin.Size = new Size(100, 30);
            btnLogin.Location = new Point(345, 300);
            btnLogin.Name = "btnLogin";
            btnLogin.Text = "Login";
            btnLogin.Click += BtnLogin_Click;

            btnLogin.BackColor = Color.FromArgb(40, 40, 40);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.ButtonColor = Color.FromArgb(27, 110, 192);
            btnLogin.OnHoverButtonColor = Color.FromArgb(27, 110, 192);
            btnLogin.OnHoverBorderColor = Color.Black;
            btnLogin.OnHoverTextColor = Color.Black;

            Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            String path = Application.StartupPath;
            TextBox user = new TextBox();
            TextBox pass = new TextBox();
            foreach (Control x in Controls)
            {
                if (x.Name == "txtUser")
                    user = x as TextBox;
                if (x.Name == "txtPassword")
                    pass = x as TextBox;
            }
            if (user.Text != "" && pass.Text != "")
            {
                if (controlPersoane.persoanaVaild(user.Text, pass.Text))
                {
                    controlPersoane.saveLogin(controlPersoane.getPersoana(user.Text));
                    Aside.Controls.Clear();
                    Main.Controls.Clear();
                    Controls.Clear();
                    layout();
                    MessageBox.Show("Complet");
                }
                else
                {
                    MessageBox.Show("Not valid");
                }
            }
        }

        public void layoutClient()
        {
            Aside.Controls.Clear();
            Main.Controls.Clear();

            mainClient(Main);
            asideClient();
        }

        public void mainClient(Panel main)
        {
            CardProfil cardProfil = new CardProfil(controlPersoane.getLoged() as Client);
            cardProfil.Location = new Point(30, 15);

            main.Controls.Add(cardProfil);
        }

        public void asideClient()
        {
            setCos(Aside);
            setIstoric(Aside);
            setLogOut(Aside);
        }

        public void setCos(Panel aside)
        {
            String path = Application.StartupPath;
            Button btnCos = new Button();
            btnCos.Name = "btnCos";
            btnCos.Text = "Cart";
            btnCos.Size = new Size(130, 40);
            btnCos.Location = new Point(0, 0);

            btnCos.ForeColor = Color.FromArgb(255, 255, 255, 255);
            btnCos.Font = new Font("Microsoft Sitka Small", 9, FontStyle.Regular);
            btnCos.TextAlign = ContentAlignment.MiddleCenter;

            btnCos.BackColor = Color.FromArgb(40, 40, 40);
            btnCos.Image = Image.FromFile(path + @"\resources\cart.png");
            
            btnCos.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnCos.Click += BtnCos_Click;

            aside.Controls.Add(btnCos);
        }

        private void BtnCos_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Orders current = controlOrders.currentCart(controlPersoane.getLoged().Id);
            if (current != null)
            {
                Lista<OrderDetails> orders = controlOrderDetails.getDetails(current.Id);
                int x = 30, y = 15;
                Node<OrderDetails> node = orders.getIterator();
                for (int i = 0; i < orders.size(); i++) 
                {
                    Panel panel = new Panel();
                    panel = new OrderCard(node.Data, control.getProdus(node.Data.ProductId), Main);
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
            gol.ForeColor = Color.White;
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
            label.Font = new Font("Microsoft Sitka Small", 10, FontStyle.Regular);
            label.ForeColor = Color.White;
            main.Controls.Add(label);

            Label lblTotal = new Label();
            lblTotal.Location = new Point(496, y + 15);
            lblTotal.Text = controlOrderDetails.sumaCart(cart).ToString() + " lei";
            lblTotal.AutoSize = false;
            lblTotal.Size = new Size(100, 40);
            lblTotal.Name = "lblTotal";
            lblTotal.TextAlign = ContentAlignment.TopCenter;
            lblTotal.Font = new Font("Microsoft Sitka Small", 10, FontStyle.Regular);
            lblTotal.ForeColor = Color.White;
            main.Controls.Add(lblTotal);
        }

        public void setComanda(Panel main, int x, int y)
        {
            RoundButton btnConfirma = new RoundButton();
            btnConfirma.Size = new Size(100, 25);
            btnConfirma.Location = new Point(30, y + 5);
            btnConfirma.Text = "Comanda";
            btnConfirma.Name = "btnConfirma";

            btnConfirma.BackColor = Color.FromArgb(40, 40, 40);
            btnConfirma.FlatStyle = FlatStyle.Flat;
            btnConfirma.FlatAppearance.BorderSize = 0;
            btnConfirma.ButtonColor = Color.FromArgb(30, 119, 216);
            btnConfirma.OnHoverButtonColor = Color.Blue;
            btnConfirma.OnHoverBorderColor = Color.Black;
            btnConfirma.OnHoverTextColor = Color.Black;

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

        public void setIstoric(Panel aside)
        {
            String path = Application.StartupPath;
            Button btnIstoric = new Button();
            btnIstoric.Name = "btnIstoric";
            btnIstoric.Text = "Historic";
            btnIstoric.Size = new Size(130, 40);
            btnIstoric.Location = new Point(0, 40);

            btnIstoric.ForeColor = Color.FromArgb(255, 255, 255, 255);
            btnIstoric.Font = new Font("Microsoft Sitka Small", 9, FontStyle.Regular);
            btnIstoric.TextAlign = ContentAlignment.MiddleCenter;

            btnIstoric.BackColor = Color.FromArgb(40, 40, 40);
            btnIstoric.Image = Image.FromFile(path + @"\resources\clock.png");

            btnIstoric.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnIstoric.Click += BtnIstoric_Click;

            aside.Controls.Add(btnIstoric);
        }

        private void BtnIstoric_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();

            Lista<Orders> lista = controlOrders.istoricOrders(controlPersoane.getLoged().Id);

            if (lista.size() > 0)
            {
                Node<Orders> node = lista.getIterator();
                int x = 30, y = 15;
                for (int i = 0; i < lista.size(); i++)
                {
                    Panel panel = new CardHistoric(node.Data);
                    panel.Location = new Point(x, y);
                    y += 115;
                    node = node.Next;
                    Main.Controls.Add(panel);
                }
            }
        }

        public void setLogOut(Panel aside)
        {
            RoundButton btnLogOut = new RoundButton();
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Text = "Log out";
            btnLogOut.Size = new Size(100, 30);
            btnLogOut.Location = new Point(15, 80);
            btnLogOut.BackColor = Color.Red;

            btnLogOut.BackColor = Color.FromArgb(40, 40, 40);
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.FlatAppearance.BorderSize = 0;
            btnLogOut.OnHoverButtonColor = Color.Red;
            btnLogOut.OnHoverBorderColor = Color.Black;
            btnLogOut.OnHoverTextColor = Color.Black;

            btnLogOut.Click += BtnLogOut_Click;

            aside.Controls.Add(btnLogOut);
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            controlPersoane.Loged = false;
            Aside.Controls.Clear();
            Main.Controls.Clear();
            layout();
        }
    }
}
