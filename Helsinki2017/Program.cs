using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Helsinki2017
{
    class Program
    {
        static List<korcsolya> Rovidlista = new List<korcsolya>();
        static List<korcsolya> dontolista = new List<korcsolya>();
        static void Main(string[] args)
        {
            StreamReader beolvasas = new StreamReader("rovidprogram.csv");
            string fejlec = beolvasas.ReadLine();
            while (!beolvasas.EndOfStream)
            {
                Rovidlista.Add(new korcsolya(beolvasas.ReadLine()));
            }
            beolvasas.Close();

            StreamReader beolvasas2 = new StreamReader("donto.csv");
            fejlec = beolvasas2.ReadLine();
            while (!beolvasas2.EndOfStream)
            {
                dontolista.Add(new korcsolya(beolvasas2.ReadLine()));
            }
            beolvasas2.Close();
            // 2. Feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine($"\tA rövidporgramban {Rovidlista.Count} induló volt");
            // 3. Feladat
            Console.WriteLine("3. feladat");
            bool bejutotte = false;
            for (int i = 0; i < dontolista.Count; i++)
            {
                if (dontolista[i].orszag == "HUN")
                {
                    bejutotte = true;
                }
            }
            if (bejutotte == true)
            {
                Console.WriteLine("\tA magyar versenyző bejutott a kűrbe");
            }
            else
            {
                Console.WriteLine("\tA magyar versenyző nem jutott be a kűrbe");
            }
            //5. Feladat
            Console.WriteLine("5. feladat");
            Console.Write("\tKérem a versenyző nevét:");
            string nev = Console.ReadLine();
            bool volte = false;
            for (int i = 0; i < Rovidlista.Count; i++)
            {
                if (nev == Rovidlista[i].nev)
                {
                    volte = true;
                }
            }
            if (volte == false)
            {
                Console.WriteLine("\tIlyen nevű induló nem volt");
            }
            //6. Feladat
            Console.WriteLine("6. feladat");
            double OPontSzam = osszPontSzam(nev);
            Console.WriteLine($"\tA versenyző összpontszáma: {OPontSzam}");
            //7. Feladat
            Console.WriteLine("7. feladat");
            List<string> OrszagLista = new List<string>();
            for (int i = 0; i < dontolista.Count; i++)
            {
                bool vane = false;
                for (int j = 0; j < OrszagLista.Count; j++)
                {
                    if (dontolista[i].orszag == OrszagLista[j])
                    {
                        vane = true;
                    }
                }
                if (vane == false)
                {
                    OrszagLista.Add(dontolista[i].orszag);
                }
            }

            int[] OrszagLista2 = new int[OrszagLista.Count];
            for (int i = 0; i < dontolista.Count; i++)
            {
                for (int j = 0; j < OrszagLista.Count; j++)
                {
                    if (dontolista[i].orszag == OrszagLista[j])
                    {
                        OrszagLista2[j]++;
                    }
                }
            }
            for (int i = 0; i < OrszagLista2.Length; i++)
            {
                if (OrszagLista2[i] > 1)
                {
                    Console.WriteLine($"\t{OrszagLista[i]} : {OrszagLista2[i]} versenyzo");
                }
            }
            //8. Feladat
            Console.WriteLine("8. feladat: vegeredmeny.csv");
            StreamWriter kiiratas = new StreamWriter("vegeredmeny.csv");
            for (int i = 1; i < dontolista.Count; i++)
            {
                korcsolya newkorcsolya = dontolista[i];
                newkorcsolya.OPontSzam = osszPontSzam(dontolista[i].nev);
                dontolista[i] = newkorcsolya;
            }

            dontolista = dontolista.OrderBy(versenyzo => versenyzo.OPontSzam).ToList();
            dontolista.Reverse();

            int helyezes = 0;
            foreach (korcsolya i in dontolista)
            {
                kiiratas.WriteLine($"{helyezes};{i.nev};{i.orszag};{i.OPontSzam}");
                helyezes++;
            }
            kiiratas.Close();
            Console.ReadKey();
        }
        //4. Feladat
        static double osszPontSzam(string nev) {
            double OPontSzam = 0;
            foreach (korcsolya i in Rovidlista)
            {
                if (i.nev == nev)
                {
                    OPontSzam += i.TechnikaiPontszam + i.KPontszam - i.hibapont;
                }
            }

            foreach (korcsolya i in dontolista)
            {
                if (i.nev == nev)
                {
                    OPontSzam += i.TechnikaiPontszam + i.KPontszam - i.hibapont;
                }
            }
            return OPontSzam;
        }

    }
    class korcsolya 
    {
        public string nev;
        public string orszag;
        public double TechnikaiPontszam;
        public double KPontszam;
        public int hibapont;
        public double OPontSzam;

        public korcsolya(string adatok) {
            string[] sorok = adatok.Split(';');
            nev = sorok[0];
            orszag = sorok[1];
            TechnikaiPontszam = Convert.ToDouble(sorok[2].Replace('.', ','));
            KPontszam = Convert.ToDouble(sorok[3].Replace('.', ','));
            hibapont = Convert.ToInt32(sorok[4]);

        
        
        }
    }
}
