using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_onlineV3.Model
{
    public class Client : Persoana
    {
        private String email;
        private String adresa;
        private String phone;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public Client(String username, String password, int id, String email, String adresa, String phone) : base(username, password, id)
        {
            this.email = email;
            this.adresa = adresa;
            this.phone = phone;
        }
        public Client(String client) : this(client.Split(',')[0], client.Split(',')[1], int.Parse(client.Split(',')[2]), client.Split(',')[3], client.Split(',')[4], client.Split(',')[5])
        {

        }

        public override bool Equals(object obj)
        {
            if(obj is Client)
            {
                Client client = obj as Client;
                if (this.Id == client.Id)
                    return true;
                return false;
            }
            return false;
        }
        
        public override string ToString()
        {
            String text = base.ToString();
            text += email + ",";
            text += adresa + ",";
            text += phone;
            return text;
        }
    }
}
