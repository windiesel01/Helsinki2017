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
            Console.ReadKey();
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
