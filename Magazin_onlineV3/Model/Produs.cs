using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin_onlineV3.Model
{
    public class Produs : IComparable<Produs>
    {
        private int id;
        private String nume = "";
        private double pret = 0;
        private int stoc = 0;
        private String descriere;
        private String pathImage;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Nume
        {
            get { return nume; }
            set { nume = value; }
        }
        public double Pret
        {
            get { return pret; }
            set { pret = value; }
        }
        public int Stoc
        {
            get { return stoc; }
            set { stoc = value; }
        }
        public String Descriere
        {
            get { return descriere; }
            set { descriere = value; }
        }
        public String PathImage
        {
            get { return pathImage; }
            set { pathImage = value; }
        }

        public Produs(String nume, double pret, int stoc, int id, String descriere)
        {
            this.nume = nume;
            this.pret = pret;
            this.stoc = stoc;
            pathImage = Application.StartupPath + @"\resources\" + nume + ".png";
            this.id = id;
            this.descriere = descriere;
        }

        public Produs(String produs) : this(produs.Split(',')[0], double.Parse(produs.Split(',')[1]), int.Parse(produs.Split(',')[2]), int.Parse(produs.Split(',')[3]), produs.Split(',')[4])
        {
            
        }

        public override string ToString()
        {
            String mesaj = "";
            mesaj += this.Nume + ",";
            mesaj += this.Pret + ",";
            mesaj += this.Stoc + ",";
            mesaj += this.id + ",";
            mesaj += this.descriere;
            return mesaj;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Produs verificare = obj as Produs;
            if (this.id == verificare.id) 
                return true;
            return false;
        }

        public int CompareTo(Produs produs)
        {
            if (this.pret > produs.pret)
                return 1;
            if (this.pret < produs.pret)
                return -1;
            return 0;
        }
    }
}
