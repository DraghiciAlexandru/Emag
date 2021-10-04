using Magazin_onlineV3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.Controlere
{
    class ControlPersoane
    {
        public Lista<Persoana> persoane;
        public Lista<Client> clienti;


        private static bool loged;

        public bool Loged
        {
            get { return loged; }
            set { loged = value; }
        }

        public ControlPersoane()
        {
            persoane = new Lista<Persoana>();
            clienti = new Lista<Client>();
            openClienti();
        }

        public void add(Persoana persoana)
        {
            Node<Persoana> pers = persoane.getLast();
            persoana.Id = pers.Data.Id + 1;
            persoane.addFinish(persoana);
        }

        public void delete(Persoana persoana)
        {
            persoane.remove(persoana);
        }

        public void openClienti()
        {
            String path = Application.StartupPath;
            StreamReader reader = new StreamReader(path + @"\clienti.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                persoane.addFinish(new Client(linie));
                clienti.addFinish(new Client(linie));
            }
            reader.Close();
        }

        public void saveClienti()
        {
            String path = Application.StartupPath;
            StreamWriter writer = new StreamWriter(path + @"\clienti.txt");
            Node<Persoana> node = persoane.getIterator();
            writer.Write(ToStringClienti());
            writer.Close();
        }

        public string ToStringClienti()
        {
            Node<Persoana> iterator = persoane.getIterator();
            String text = "";
            while (iterator != null)
            {
                if (iterator.Data is Client)
                    text += iterator.Data.ToString() + Environment.NewLine;
                iterator = iterator.Next;
            }
            return text;
        }

        public void saveLogin(Persoana persoana)
        {
            loged = true;

            String path = Application.StartupPath;
            StreamWriter writer = new StreamWriter(path + @"\login.txt");

            writer.Write(persoana.Id);

            writer.Close();
        }

        public bool persoanaVaild(String username, String password)
        {
            Node<Persoana> node = persoane.getIterator();
            for (int i = 0; i < persoane.size(); i++) 
            {
                if (node.Data.Username == username && node.Data.Password == password) 
                    return true;
                node = node.Next;
            }
            return false;
        }

        public Persoana getPersoana(String username)
        {
            Node<Persoana> node = persoane.getIterator();
            for (int i = 0; i < persoane.size(); i++)
            {
                if (node.Data.Username == username)
                    return node.Data;
                node = node.Next;
            }
            return null;
        }

        public Persoana getPersoana(int id)
        {
            Node<Persoana> node = persoane.getIterator();
            for (int i = 0; i < persoane.size(); i++)
            {
                if (node.Data.Id == id) 
                    return node.Data;
                node = node.Next;
            }
            return null;
        }

        public Persoana getLoged()
        {
            String path = Application.StartupPath;
            StreamReader reader = new StreamReader(path + @"\login.txt");

            Persoana x = getPersoana(int.Parse(reader.ReadLine()));

            reader.Close();

            return x;
        }
    }
}
