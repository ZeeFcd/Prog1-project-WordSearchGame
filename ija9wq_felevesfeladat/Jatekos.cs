using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ija9wq_felevesfeladat
{
    class Jatekos
    {
        //adattagok
        int pontszam;
        string bekertszo;

        //konstruktor
        public Jatekos() 
        {
            pontszam = 0;
            bekertszo ="";

        }
            


        //tulajdonságok
        public int Pontszam
        {
            get { return pontszam; }
            set { pontszam = value; }

        }
        public string Bekertszo 
        {
            get { return bekertszo; }
            set { bekertszo = value; }
        }


    }
}
