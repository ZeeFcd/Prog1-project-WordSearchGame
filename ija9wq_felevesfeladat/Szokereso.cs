using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ija9wq_felevesfeladat
{
    class Szokereso
    {
        string[] tablaszavai; //= {"pék","lapát","asztal" };
             

        private void Szo_kereses(char[,] _matrix, bool[,] _ittjart_mezo, int _sor, int _oszlop, string _szo, ref bool _megtalalta)//, int  _honnan_sor, int  _honnan_oszlop)
        {

            _ittjart_mezo[_sor, _oszlop] = true;  // beállítjuk a startra a true-t hogy véletlenül se hívja meg magát erre megint  a metódus.
            _szo = _szo.Remove(0, 1); //kiszedjük azt az elemet amit már megtaláltunk(annak a mezőnek az eleme amin éppen álunk.)


            if (_szo != "")
            {
                for (int i = _sor - 1; i <= _sor + 1; i++)
                {

                    for (int j = _oszlop - 1; j <= _oszlop + 1; j++)
                    {// ha az i és a j még nem futnak ki a mátrixok paramétereiből és a bool mátrixban false az érték(azaz nem járt még ott) és a vizsgált mező megegyezik a szó következő karakterével, akkor hívja meg önmagát ezzel a koordinátával.


                        if ((i >= 0 && i < _matrix.GetLength(0)) && (j >= 0 && j < _matrix.GetLength(1)) && _ittjart_mezo[i, j] == false && _szo[0] == _matrix[i, j])
                        {


                            Szo_kereses(_matrix, _ittjart_mezo, i, j, _szo, ref _megtalalta);//,_sor,_oszlop);


                        }
                    }

                }

            }
            else
            {

                _megtalalta = true;
            }



        }

        public string[] Osszes_Szo_Kereses(char[,] _matrix, string[] _szavak)
        {
            string tablaszavai_string = "#"; //tabla szavai stringben, #-el elválasztva
            bool megtalalta = false;
            bool[,] ittjart_mezo = new bool[4, 4];
            int sor = 0;
            int oszlop = 0;

            // végigmegy a szavak tömbön és azon belül a táblát tartalmazó mátrixban
            for (int n = 0; n < _szavak.Length; n++) // az összes szótárban lévő szóra csinálja meg ezt
            {

                for (int i = 0; i < _matrix.GetLength(0); i++) //mátrix bejárás sorai
                {
                    for (int j = 0; j < _matrix.GetLength(1); j++) //mátrix bejárás oszlopai
                    {
                        BoolMatrix_reset(ref ittjart_mezo);
                        megtalalta = false;
                        if (_szavak[n][0] == _matrix[i, j])// ha megyegyezik a keresett szó első betűje a tábla betűjével, akkor keressen
                        {
                            sor = i;
                            oszlop = j;
                            Szo_kereses(_matrix, ittjart_mezo, sor, oszlop, _szavak[n], ref megtalalta);//, -1, -1);
                            if (megtalalta) // ha megtalalta a szót, akkor mentse is el
                            {
                                if (tablaszavai_string.Contains("#"+_szavak[n]+ "#") == false) // ha a string tömb tartalmazza, a már megtalált szót akkor ne mentse el kétszer.
                                {
                                    tablaszavai_string += _szavak[n] + "#";
                                }


                            }
                        }
                    }
                }




            }

            tablaszavai_string = tablaszavai_string.Trim('#');  // leszedi a felesleges hashteget a végéről
            string[] tablaszavai = tablaszavai_string.Split('#');// stringből string tömböt csinál #-geknél tördelés
            return tablaszavai;
        }

        // ez azért kell, mivel nem csak egyszer fogom megnézni ,hogy kirakható egy szó , minde egyes alkalomal le kell resetelnem azt hogy holn jártam.
        private void BoolMatrix_reset(ref bool[,] boolmatrix)
        {

            for (int i = 0; i < boolmatrix.GetLength(0); i++)
            {
                for (int j = 0; j < boolmatrix.GetLength(1); j++)
                {
                    boolmatrix[i, j] = false;
                }
            }

        }






        public Szokereso()
        {
            tablaszavai = Osszes_Szo_Kereses( Jatek.Tabla,  Jatek.Szavak);
        }

        public string[] Tablaszavai
        {
            get { return tablaszavai; }
        }
    }
}
