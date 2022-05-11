using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ija9wq_felevesfeladat
{
    class Jatek
    {
        //Adattagok, a legtöbb az statikus objektum, ezek tulajdonságaival dolgoznak össze az objektumok
        #region
        static Fajlbeolvas beolvasott=new Fajlbeolvas();
        static TablaGenerator letrehozottTabla = new TablaGenerator();
        static Szokereso tablabanMegkeresettSzavak = new Szokereso();
        static Kirajzolo rajzolo = new Kirajzolo(Jatek.Tabla);
        string[] megtalaltszavak; //játkos által megtalált szavak
        int idx_megtalaltszavak;  // az előző tömb indexelője
        #endregion

        //Konstruktor
        public Jatek()
        {   //játékos létrehozása a játékhoz szükséges paraméterek lekérése/beállítása
            Jatekos jatekos = new Jatekos();
            megtalaltszavak = new string[Jatek.Tablaszavai.Length]; // megtalált szó csak annyi szó lehet, amennyi a játéktáblából kirakható (amennyit szót tartalmaz a tábla) 
            idx_megtalaltszavak = 0; //indexelő beállítása

            
            rajzolo.TablaKirajzolas(Jatek.Tabla);

            do
            {
                jatekos.Bekertszo = Console.ReadLine();      //szó bekérése a felhasználótól

                if (jatekos.Bekertszo!="k")   // ez azért van hogy ne fusson le feleslegesen ez az ág ,ha a játékos kiakar lépni.
                {
                    bool pontoter = PontotEre_JatekosSzava(megtalaltszavak, Jatek.Tablaszavai, jatekos.Bekertszo); //megvizsgálja hogy pontot ér-e a felhasználó szava.
                    bool szotarban_bennevan = Linearis_Kereses(Jatek.Szavak,jatekos.Bekertszo);
                    if (pontoter)
                    {
                        jatekos.Pontszam += jatekos.Bekertszo.Length * jatekos.Bekertszo.Length;
                        rajzolo.PontotereKiiras(pontoter, szotarban_bennevan);
                        rajzolo.Pontjelzo(jatekos.Pontszam, jatekos.Bekertszo);
                       
                        megtalaltszavak[idx_megtalaltszavak] = jatekos.Bekertszo;    // a két sorban azt történik, hogy elmentjük a felhasználó által megadott jó megoldásokat egy tömbben,akkor ha először találja meg.
                        idx_megtalaltszavak++;

                    }
                    else if(szotarban_bennevan==false)
                    {
                        rajzolo.PontotereKiiras(pontoter, szotarban_bennevan);
                    }
                    else
                    {
                        rajzolo.PontotereKiiras(pontoter, szotarban_bennevan);
                    }
                }

             //addig kéri be a szavakat, ameddig meg nem találja az összeset, vagy "k" beírásával, ki nem akar lépni. Ha a megtalált szavak indexelője eléri, a tömb utolsó elemének indexét, azt jelenti, hogy megtaláltuk az összes szót tehát vége a játéknak.
            } while (jatekos.Bekertszo != "k"&& idx_megtalaltszavak<megtalaltszavak.Length);

            //Statisztika teljesítmény összegzés
            rajzolo.Statisztika(jatekos.Pontszam,Jatek.Tablaszavai, idx_megtalaltszavak);

            //játék vége

           
        }

        //játék metódusai
        #region
        //A bekért szó pontot ér e vagy nem? kérdésre adja a választ a függvény (true=igen, false= nem) 
        public bool PontotEre_JatekosSzava(string[] elhasznaltszavak,string[] tablaszavai,string bekertszo) 
        {
                        
            if (!Linearis_Kereses(elhasznaltszavak, bekertszo)) // Ha a bekért szó nincs ott, a már megtalált szavaknál, akkor megkeresi,hogy a tablaszavai közt ott van-e a bekért szó
            {
                return Linearis_Kereses(tablaszavai, bekertszo);

            }
            else
            {
                return false;    //Itt benne van a bekért szó, a már metalált szavaknál ,így nem vizsgálom meg ,hogy benne van e magában táblában.
            }
           
        }

        // Lineáris keresés tétel, string tömbbel és stringgel végrehajtva
        public bool Linearis_Kereses(string[] szavaktomb, string szo)
        {
            int n = 0;
            while (n < szavaktomb.Length && szo != szavaktomb[n])
            {
                n++;
            }

            return n < szavaktomb.Length;

        } 
        #endregion



        //Tulajdonságok
        #region
        public static string[] Szavak
        {
            get {return  beolvasott.Szavak; }
        }
        public static char[,] Tabla
        {

            get { return letrehozottTabla.Tabla; }
        }
        public static string[] Tablaszavai
        {
            get{ return tablabanMegkeresettSzavak.Tablaszavai; }
        }
        #endregion


    }
}
