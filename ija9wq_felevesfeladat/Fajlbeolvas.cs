using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ija9wq_felevesfeladat
{
    class Fajlbeolvas
    {

        
        string[] szavak;          //string tömb amiben a szavak vannak

        public Fajlbeolvas()
        {
            
            szavak = File.ReadAllLines("szavak.txt"); // a szótár soronként tartalmazza a szavakat

        }

        public string[] Szavak                                  //szavak tömb getter metódusa;
        {
            get{ return szavak; }
        }


    }
}
