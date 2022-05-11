using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ija9wq_felevesfeladat
{
    class Kirajzolo
    {
        //koordináták ahonnan a táblát és minden mást néz a program, egy char[,] tömb ami hivatkozni fog majd az eredeti táblára)
        int j_startpont;//vízszintes koordináta
        int i_startpont; //függőleges koordináta
        char[,] tabla;

        //konstruktor
        public Kirajzolo(char[,] _tabla)
        {//tábla indulási helyéne beállítása
            Console.WindowHeight = _tabla.GetLength(0) * 9;
            Console.WindowWidth = _tabla.GetLength(1) * 9;
            j_startpont = Console.WindowWidth / 2 - _tabla.GetLength(1);
            i_startpont = Console.WindowHeight / 2 - _tabla.GetLength(0);
            tabla = _tabla;
        }


        //Kiiró metódusok
        #region
        //aktuális pont kiírása
        public void Pontjelzo(int _pontszam, string _bekertszo) 
        {
            Console.SetCursorPosition(j_startpont+7, i_startpont-2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+" + _bekertszo.Length * _bekertszo.Length);
            Console.ForegroundColor = ConsoleColor.White;

            System.Threading.Thread.Sleep(650);
            Console.SetCursorPosition(j_startpont + 7, i_startpont - 2);
            Console.Write("               ");

            Console.SetCursorPosition(j_startpont + 2, i_startpont - 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(_pontszam);
            Console.ForegroundColor = ConsoleColor.White;

            // szóbekérés helyére ugrás
            Console.SetCursorPosition(0, i_startpont + 7);

        }
        //üzenet, vizsgája hogy a bekért szó kirakható-e,benne van-e a szótárban(miért nem fogad el egy szót. Azért kel1, hogy látszódjon, hogy működik a program ) 
        public void PontotereKiiras(bool bennevan,bool _szotarban_bennevan)
        {
            // ha kirakható a táblából
            if (bennevan)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Keptorles_sor(i_startpont - 5, 2);
                Console.SetCursorPosition(j_startpont-10, i_startpont-5);
                Console.WriteLine("A szó benne van a tábálában.:)");
                Keptorles_sor(i_startpont + tabla.GetLength(1) + 3, 1);
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, i_startpont + tabla.GetLength(1) + 3);
            }
            // ha nem rakható ki és nincs benne a szótárban
            else if (_szotarban_bennevan==false) 
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Keptorles_sor(i_startpont - 5, 2);
                Console.SetCursorPosition(j_startpont - 10, i_startpont - 5);
                Console.WriteLine("A szó sajnos nincs benne -.-\n             a szótárban. ");
                Keptorles_sor(i_startpont + tabla.GetLength(1) + 3, 1);
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, i_startpont + tabla.GetLength(1) + 3);
            }
            // ha nem rakható ki de benne van a szótárban
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Keptorles_sor(i_startpont - 5, 2);
                Console.SetCursorPosition(j_startpont - 10, i_startpont - 5);
                Console.WriteLine("A szó nincs benne a táblában,\n    vagy már megtaláltad. :(");
                Keptorles_sor(i_startpont + tabla.GetLength(1) + 3, 1);
                Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(0, i_startpont + tabla.GetLength(1) + 3);
            }


        }
        //tábla kirajzolása kerettel+üzenet a felhasználóünak.
        public void TablaKirajzolas(char[,] _tabla) 
        {
            Console.Clear();
            //Tábla kirajzolása
            Console.SetCursorPosition(j_startpont, i_startpont);
            for (int j = 0; j < _tabla.GetLength(0); j++)
            {
                
                for (int i = 0; i < _tabla.GetLength(1); i++)
                {
                    
                    Console.Write(char.ToUpper(_tabla[i, j])+" ");
                    System.Threading.Thread.Sleep(60);
                }
                Console.SetCursorPosition( i_startpont,j_startpont+j+1);
                
            }
            //Vízszintes keret  kirajzolás
            for (int j = 0; j < _tabla.GetLength(1)*2-1; j++)
            {
                Console.SetCursorPosition(j_startpont+j, i_startpont -1);
                Console.Write("-");

                Console.SetCursorPosition(j_startpont+j, i_startpont+_tabla.GetLength(0));
                Console.Write("-");
                System.Threading.Thread.Sleep(60);
            }
            //Függőleges keret  kirajzolás
            for (int i = 1; i < _tabla.GetLength(0)+3; i++)
            {
                
                Console.SetCursorPosition(j_startpont -1, i_startpont +i-2);
                if (i % 6 == 1 || i % 6 == 0)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write("|");
                }

                Console.SetCursorPosition(j_startpont + _tabla.GetLength(1)*2 - 1, i_startpont + i-2);
                if (i % 6 == 1 || i % 6 == 0)
                {
                    Console.Write("+");
                }
                else
                {
                    Console.Write("|");
                }

                System.Threading.Thread.Sleep(60);

            }

            //Üzenet a felhasználónak
            #region
            Console.SetCursorPosition(4, 1);
            Console.Write("Üdvözöllek a Szókirakóban!");
            System.Threading.Thread.Sleep(1000);
            Console.SetCursorPosition(4, 2);
            Console.Write("A játék célja, hogy minél");
            Console.SetCursorPosition(1, 3);
            Console.Write("több szót tudj kirakni a táblából.");
            System.Threading.Thread.Sleep(2500);
            Console.SetCursorPosition(1, 4);
            Console.Write("Minden eltalált szóért, a szóhossz");
            Console.SetCursorPosition(2, 5);
            Console.Write("négyzetét kapod meg pontszámnak");
            System.Threading.Thread.Sleep(2500);
            Console.SetCursorPosition(2, 6);
            Console.Write("Ha kiakarsz lépni, írj be (k)-t");
            Console.SetCursorPosition(0, 7);
            Console.Write("és a játék összegzi a teljesítményed");
            System.Threading.Thread.Sleep(2000);
            Console.SetCursorPosition(0, i_startpont + _tabla.GetLength(1) + 2);
            Console.Write("Kérem a táblából kirakható szavakat:");
            #endregion

            //pontjelző
            Console.SetCursorPosition(j_startpont - 10, i_startpont - 2);
            Console.Write("pontszám:  {   }");

            //szóbekérés helyére ugrás
            Console.SetCursorPosition(0, i_startpont+ _tabla.GetLength(1)+3);

        }
        //képernyő törlése soronként
        private void Keptorles_sor(int hanyadiksor, int hanysor) // az első paraméter koordináta, második onnantól hány sor
        {
            Console.SetCursorPosition(0, hanyadiksor);
            for (int i = 0; i < hanysor; i++)
            {
                for (int j = 0; j <Console.WindowWidth; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine();
            }


        }
        //statisztika/játék vége
        public void Statisztika(int _pontszam, string[] _kirakhatoszavak ,int _eltalaltszavakdb )
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Kirakható szavak");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Eltalált");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Pontszám");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("----------------+--------+----------");

            for (int i = 2; i < _kirakhatoszavak.Length+2; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(_kirakhatoszavak[i-2]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(16,i);
                Console.Write("|");
            }

            Console.SetCursorPosition(20, 2);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(_eltalaltszavakdb+" db");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 2; i < _kirakhatoszavak.Length + 2; i++)
            {
                Console.SetCursorPosition(25, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(27, 2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(_pontszam);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 2 + _kirakhatoszavak.Length);
            Console.WriteLine("----------------+--------+----------");

            if (_kirakhatoszavak.Length== _eltalaltszavakdb)
            {
                Console.SetCursorPosition(0, 3 + _kirakhatoszavak.Length);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("SIKER! Eltaláltad az összes szót!");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.SetCursorPosition(0, 3 + _kirakhatoszavak.Length);
            }


            Console.Write("Nyomj entert a kilépéshez...");

            Console.ReadLine();
        }
        #endregion

    }
}
