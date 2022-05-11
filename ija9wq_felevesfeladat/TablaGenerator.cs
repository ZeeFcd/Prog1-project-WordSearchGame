using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ija9wq_felevesfeladat
{
    class TablaGenerator
    {
        //adattagok
        #region 
        int[] elofordulas;
        string osszbetu;
        string betuk;
        string msh;
        string mgh;
        char[,] tabla;
        #endregion

        //Szereplési gyakoriság alapán generált, a betűhöz tartozó metódusok/függvények
        #region

        //Betű kisorsolása gyakorisági valószínűség alapján
        private char BetuGenerator(Random r, int szum) //paraméternek megkap egy random generátort és a Teljes valószínűséget
        {

            int idx = 0; // indexelő a gyakoriságban(darabszámok összege), jelentése: az indexelés az aktuális darabszám által történik
            int n = 0; // indexelő a betuk/elofordulas tömbben
            int valoszinuseg = r.Next(1, szum + 1); // random szám 1 és az Teljes valószínűség között

            while (n < betuk.Length && idx < valoszinuseg)  //A lényege a ciklusnak, hogy minden betűindexhez tartozik egy darabszámnagyság, és ha a db-ket  összeadom az arányos azzal ha maga a tömb indexelőjét léptetem 1-gyel.
            {                                               //Ez olyan mintha felírnám így a betűket: "BBCCCAAAHHLLLDEEJ" léptetek 1 betűknél(n=n++ ;mondjuk B--->C) az az előbb felírt tömben(idx=2+3;  2db B + 3db C) 
                idx = idx + elofordulas[n];                 //Addig lépked az idx amíg a valoniszuséget vagy eléri vagy átugorja, ha "idx=valoszinuseg", akkor az "n" indexelő még az utolsó lépésnél átugrik a következőbe, ha idx>valoszinuseg akkor meg eleve az az eggyel nagyobb indexnél fog álni "n".
                n++;
            }

            return betuk[n - 1]; //A fent leírt viselkedés alapján ezért az "n-1" dik betű lesz amit keresek

        }

        //Teljes valószínűség(betűk darabszámának összege)
        private int Teljesvaloszinuseg(int[]elofordulas)
        {
            int szum = 0;
            for (int i = 0; i < elofordulas.Length; i++) // Összeadja az összes betű darabszámát 
            {
                szum += elofordulas[i];
            }
            return szum;
        }

        // Az objektum két adattagjába elmentjük az Előforduló betűket és darabszámaikat
        private void Betuk_Elofordulasuk_Feltoltese()
        {
            
            osszbetu = String.Join("", Jatek.Szavak);// A szavak tömbből stringet csinál, hogy egybe tudja kezelni a betűket
            Elofordulas(osszbetu, ref elofordulas, ref betuk); // itt most akkor van 2 tömb ami tartalmazza a betűket és hogy mennyiszer fordulnak elő.

        }

        // Az egyes betűk előfordulási darabszámának megállapítása
        private void Elofordulas(string osszbetu, ref int[] elofordulas, ref string betuk)
        {
            betuk = "";
            for (int i = 0; i < osszbetu.Length; i++) // kiszedi az összes szótárban található betűt, úgy hogy csak egyszer szerepeljen 
            {

                if (!betuk.Contains(osszbetu[i]))   //ha a betük string nem tartalmazza még a soronkövetkező betűt, az összes betűből, akkor magához fűzi.
                {
                    betuk = betuk + osszbetu[i];
                }

            }

            elofordulas = new int[betuk.Length]; //int tömb ami tarlamazza az adott betűhöz tartozó darabszámot

            for (int i = 0; i < osszbetu.Length; i++)
            {
                elofordulas[betuk.IndexOf(osszbetu[i])]++;  // Az öszbetűben éppen aktuális karakter(osszbetu[i]) indexhelye a betük tömben(betuk.IndexOf()), megyezik az (elofordulas) int tömben levő darabszám indexhelyével.
                                                            // így a (betuk.IndexOf(osszbetu[i])) indexen levő darabszámot megnövelem. Egy példa:3db a, 2db b, 1db c ---> betuk={a,b,c} előfordulás={3,2,1} 
            }


        }

        #endregion

        //Magánhangzó mássalhangzó elhelyeszkedéséhez szükséges metódusok
        #region
        private bool msh_valoszinuseg(int _sor, int _oszlop,string _msh,string _mgh,char[,] _tabla,Random r)
        {
            int msh_szum = 0; //msh darabszám
            int mgh_szum = 0;//mgh darabszám

            // összeszámolja  az előtte legenerált betűket
            for (int i = _sor-1; i <= _sor; i++)
            {
                for (int j = _oszlop-1; j < _oszlop+1; j++)
                {
                    if ((i >= 0 && i < tabla.GetLength(0)) && (j >= 0 && j < tabla.GetLength(1)) ) /// azért hogy ne mutasson ki a mátrixból
                    {
                        if (_msh.Contains(tabla[i,j]))
                        {
                            msh_szum++;

                        }
                        else if (_mgh.Contains(tabla[i, j]))
                        {
                            mgh_szum++;
                        }


                    }
                }
            }

            //súlyozom az msh generálást az alapján, hogy az éppen generálódó betűnek a szomszédja mgh, akkor 2/3 a valószínűsége az,hogy msh lesz a következő.
            //De mivel itt nem csak egy szomszéd van így eloszlik az 1 valószínég összesen minding annyi mezőre amennyi már le van generálva. Ezért----->az msh valószínűség képlete  (mgh_sum / (msh_sum + mgh_sum)) * 2/3

            int szamlalo = mgh_szum*2;
            int nevezo = (msh_szum + mgh_szum)*3;
            int random = r.Next(1,nevezo+1);

            if (random>szamlalo) //magánhanzó
            {
                return false;
            }
            else // mássalhangzó
            {
                return true;
            }

            
        }




        #endregion

        //Konstruktor
        public TablaGenerator()
        {
            // betűgeneráláshoz szükséges metődusok meghívása
            msh ="bcdfghjklmnpqrstvwxyz";
            mgh = "aáeéiíoóöőuúüű";
            tabla = new char[4, 4];
            Random r = new Random();
            Betuk_Elofordulasuk_Feltoltese();
            char generaltbetu ;
            int osszdarabszam=Teljesvaloszinuseg(elofordulas);               
                       

            for (int i = 0; i < tabla.GetLength(0); i++) // char mátrix minden eleméhez meghívja a betűgenerátort
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (i==0&&j==0) // ezt azért hogy az első betű ne mindig mgh legyen mert, mivel nincs mellette semmi ezért logika szerint ez olyan mintha nem lenne mellette magáhangzó ,tehát 0 a valószínűség arra hogy msh lesz
                    {
                        generaltbetu = BetuGenerator(r, osszdarabszam);
                        tabla[i, j] = generaltbetu;
                    }
                    else if (msh_valoszinuseg(i, j, msh, mgh, tabla,  r)) //ha msh
                    {// addig generlál gyakoriság alapján ameddig nem msh
                        do
                        {
                            generaltbetu= BetuGenerator(r, osszdarabszam);
                        } while (!msh.Contains(generaltbetu));

                        

                        tabla[i, j] = generaltbetu;
                    }
                    else// ha mgh
                    {// addig generlál gyakoriság alapján ameddig nem mgh
                        do
                        {
                            generaltbetu = BetuGenerator(r, osszdarabszam);
                        } while (!mgh.Contains(generaltbetu));

                        tabla[i, j] =generaltbetu ;
                    }



                    
                }
            }





                                    
        }

        //Tulajdonságok

        public char[,] Tabla
        {
            get { return tabla; }

        }



        




    }
}
