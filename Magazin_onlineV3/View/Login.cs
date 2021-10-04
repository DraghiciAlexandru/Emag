using Magazin_onlineV3.Controlere;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.View
{
    class Login : Panel
    {
        ControlPersoane control;

        public Login()
        {
            control = new ControlPersoane();
            layout();
        }

        public void layout()
        {
            this.Size = new Size(790, 350);
            this.Location = new Point(0, 50);

            setUsername();
            setPassword();
            setLogin();
        }

        public void setUsername()
        {
            TextBox box = new TextBox();
            box.Size = new Size(200, 25);
            box.Location = new Point(295, 200);
            box.Name = "txtUser";

            Controls.Add(box);
        }

        public void setPassword()
        {
            TextBox box = new TextBox();
            box.Size = new Size(200, 25);
            box.Location = new Point(295, 240);
            box.Name = "txtPassword";

            Controls.Add(box);
        }

        public void setLogin()
        {
            Button button = new Button();
            button.Size = new Size(100, 30);
            button.Location = new Point(345, 280);
            button.Name = "btnLogin";
            button.Text = "Login";

            button.Click += Button_Click;

            Controls.Add(button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            TextBox user = new TextBox();
            TextBox pass = new TextBox();
            foreach(Control x in Controls)
            {
                if (x.Name == "txtUser")
                    user = x as TextBox;
                if (x.Name == "txtPassword")
                    pass = x as TextBox;
            }

            if (user.Text != "" && pass.Text != "") 
            {
                if (control.persoanaVaild(user.Text, pass.Text))
                {
                    control.saveLogin(control.getPersoana(user.Text));
                    MessageBox.Show("Valid");
                }
                else
                {
                    MessageBox.Show("Not valid");
                }
            }
        }

    }
}

