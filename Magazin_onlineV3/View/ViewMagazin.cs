using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.View
{
    abstract class ViewMagazin : Form
    {
        public Panel Header;
        public Panel Footer;

        public ViewMagazin()
        {
            Header = new Panel();
            Footer = new Panel();
            layout();
        }

        public void layout()
        {
            setForma();
            setHead(Header);
            setFooter(Footer);
            setExit(Footer);
        }

        public void setForma()
        {
            String path = Application.StartupPath;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.None;
            Size = new Size(790, 450);
            StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Emag";
            this.Icon = new Icon(path + @"\resources\cartIcon.ico");
        }

        public void setHead(Panel header)
        {
            String path = Application.StartupPath;
            header.Location = new Point(0, 0);
            header.Size = new Size(Width, 50);
            header.BorderStyle = BorderStyle.FixedSingle;

            header.BackgroundImage = Image.FromFile(path + @"\resources\Header.png");
            header.BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(header);
        }

        public abstract void setAside(Panel aside);

        public abstract void setMain(Panel main);

        public void setFooter(Panel footer)
        {
            footer.Location = new Point(0, 400);
            footer.Size = new Size(Width, 50);
            footer.BorderStyle = BorderStyle.FixedSingle;
            footer.BackColor = Color.FromArgb(20, 20, 20);
            Controls.Add(footer);
        }

        public void setExit(Panel footer)
        {
            RoundButton btnExit = new RoundButton();
            btnExit.Name = "btnExit";
            btnExit.Location = new Point(660, 12);
            btnExit.Size = new Size(90, 25);
            btnExit.Text = "Exit";
            btnExit.Click += BtnExit_Click;

            btnExit.BackColor = Color.FromArgb(20, 20, 20);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.OnHoverButtonColor = Color.Red;
            btnExit.OnHoverBorderColor = Color.Black;
            btnExit.OnHoverTextColor = Color.Black;

            footer.Controls.Add(btnExit);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ViewMagazin
            // 
            this.ClientSize = new System.Drawing.Size(278, 244);
            this.Name = "ViewMagazin";
            this.Load += new System.EventHandler(this.ViewMagazin_Load);
            this.ResumeLayout(false);
        }

        private void ViewMagazin_Load(object sender, EventArgs e)
        {

        }
    }
}
