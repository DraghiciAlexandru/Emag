using Magazin_onlineV3.Model;
using Magazin_onlineV3.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.Controlere
{
    class ControlProdus
    {
        private Lista<Produs> lista;

        public Lista<Produs> Lista
        {
            get { return lista; }
        }

        public ControlProdus()
        {
            lista = new Lista<Produs>();
     
            open();
        }

        public void open()
        {
            String path = Application.StartupPath;
            StreamReader reader = new StreamReader(path + @"\produse.txt");
            String linie = "";
            while ((linie = reader.ReadLine()) != null)
            {
                lista.addFinish(new Produs(linie));
            }
            reader.Close();
        }

        public void save()
        {
            String path = Application.StartupPath;
            StreamWriter writer = new StreamWriter(path + @"\produse.txt");


            writer.Write(this);
         
            writer.Close();
        }

        public void add(Produs produs)
        {
            produs.Id = lista.getLast().Data.Id + 1;

            lista.addFinish(produs);
        }

        public void delete(int id)
        {
            lista.remove(new Produs("placeholder", 1.1, 0, id, ""));
        }

        public override string ToString()
        {
            Node<Produs> iterator = lista.getIterator();
            String text = "";
            while (iterator != null) 
            {
                text += iterator.Data.ToString() + Environment.NewLine;
                iterator = iterator.Next;
            }
            return text;
        }

        public Lista<Produs> produseFiltrate(Panel aside)
        {
            Price price = null;
            Lista<Produs> produs = new Lista<Produs>();
            foreach (Control x in aside.Controls) 
            {
                if (x.Name == "pnlPrice")
                    price = x as Price;
            }
            Node<Produs> node = lista.getIterator();
            for (int i = 0; i < lista.size(); i++) 
            {
                if (node.Data.Pret >= price.Minim && node.Data.Pret <= price.Maxim)
                    produs.addFinish(node.Data);
                node = node.Next;
            }

            return produs;
        }

        public Lista<Produs> produseSortate(Panel sortare)
        {
            ComboBox sort = null;
            Lista<Produs> produs = new Lista<Produs>();
            foreach (Control x in sortare.Controls)
            {
                if (x.Name == "cboSortare")
                    sort = x as ComboBox;
            }
            Node<Produs> node = lista.getIterator();
            int flag = 1;
            if (sort.SelectedItem.ToString() == "Pret crescator")
            {

            }
            return produs;
        }

        public Produs getProdus(int id)
        {
            Node<Produs> node = lista.getIterator();
            for (int i = 0; i < lista.size(); i++) 
            {
                if (node.Data.Id == id)
                    return node.Data;
                node = node.Next;
            }
            if (lista.getLast().Data.Id == id)
                return lista.getLast().Data;
            return null;
        }
    }
}
