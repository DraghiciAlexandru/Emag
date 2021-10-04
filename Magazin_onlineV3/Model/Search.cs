using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin_onlineV3.Model
{
    class Search
    {
        private Lista<Produs> lista;

        public Search(Lista<Produs> lista)
        {
            this.lista = lista;
        }

        public Lista<Produs> GetProdus(String nume)
        {
            Lista<Produs> noua = new Lista<Produs>();
            Node<Produs> node = lista.getIterator();
            for (int i = 0; i < lista.size(); i++) 
            {
                if (node.Data.Nume.Contains(nume))
                    noua.addFinish(node.Data);
            }
            return noua;
        }
    }
}
