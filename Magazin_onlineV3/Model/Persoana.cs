using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_onlineV3.Model
{
    public abstract class Persoana : IComparable<Persoana>
    {
        private int id;
        private String username;
        private String password; 

        public String Username
        {
            get => username;
            set => username = value;
        }
        public String Password
        {
            get { return password; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public Persoana(String username, String password ,int id)
        {
            this.username = username;
            this.password = password;
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            Persoana persoana = obj as Persoana;
            if (this.id == persoana.id)
                return true;
            return false;
        }

        public override string ToString()
        {
            String text = "";
            text += username + ",";
            text += password + ",";
            text += id + ",";
            return text;
        }

        public int CompareTo(Persoana persoana)
        {
            return username.CompareTo(persoana);
        }
    }
}
