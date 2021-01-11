using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210111
{
    class Program
    {
        struct Orszag
        {
            public string Nev;
            public int Reszvetelek;
            public int Elso;
            public int Utolso;
            public string Legjobb;

            public Orszag(string sor)
            {
                var t = sor.Split(';');

                Nev = t[0];
                Reszvetelek = int.Parse(t[1]);
                Elso = int.Parse(t[2]);
                Utolso = int.Parse(t[3]);
                Legjobb = t[4];
            }
        }

        static List<Orszag> orszagok = new List<Orszag>();
        static int elso = int.MaxValue;

        static void Main()
        {
            Beolvas();
            
            F1();
            F2();
            F3();
            F4();
            F5();
            F6();
            F7();
            F8();
            
            Console.ReadLine();
        }

        private static void F8()
        {
            var sw = new StreamWriter(@"../../res/legtobbszor.txt");

            foreach (var orszag in orszagok)
            {
                if (orszag.Reszvetelek >= 10) sw.WriteLine($"{orszag.Nev}: {orszag.Reszvetelek}");
            }

            sw.Flush();
            sw.Close();

            Console.WriteLine("8. feladat: legtobbszor.txt kész!");
        }

        private static void F7()
        {
            //az első vb évszámát már eltároltam a 4. feladatban

            int i = 0; //szerintem feltételezhetem, hogy BIZTOSAN van benne Magyarország
            while (orszagok[i].Nev != "Magyarország") i++;

            if (orszagok[i].Elso == elso) Console.WriteLine("7. feladat: Magyarország ott volt az első VB-n\r\n");
            else Console.WriteLine("7. feladat: Magyarország nem volt ott az első VB-n\r\n");
        }

        private static void F6()
        {
            string legjobb;

            int i = 0; //szerintem feltételezhetem, hogy BIZTOSAN van benne Szlovákia
            while (orszagok[i].Nev != "Szlovákia") i++;

            Console.WriteLine($"6. feladat: Szlovákia legjobb eredménye: {orszagok[i].Legjobb}\r\n");
        }

        private static void F5()
        {
            int vilagbajnok = 0;

            foreach (var orszag in orszagok)
            {
                if (orszag.Legjobb.Contains("Világbajnok")) vilagbajnok++;
            }

            Console.WriteLine($"5. feladat: Eddig {vilagbajnok} ország csapata volt világbajnok\r\n");
        }

        private static void F4()
        {
            for (int i = 0; i < orszagok.Count; i++)
            {
                if (orszagok[i].Elso < elso) elso = orszagok[i].Elso;
            }

            Console.WriteLine($"4. feladat: Az első VB-t {elso}-ban/ben rendezték\r\n");
        }

        private static void F3()
        {
            int benelux = 0;
            
            foreach (var orszag in orszagok)
            {
                if (orszag.Nev == "Belgium" || orszag.Nev == "Hollandia" || orszag.Nev == "Luxemburg") benelux += orszag.Reszvetelek;
            }

            Console.WriteLine($"3. feladat: A BeNeLux államok összesen {benelux} alkalommal vettek részt a VB-n\r\n");
        }

        private static void F2()
        {
            List<string> legutobbiVB = new List<string>();

            foreach (var orszag in orszagok)
            {
                if (orszag.Utolso == 2018) legutobbiVB.Add(orszag.Nev);
            }

            Console.WriteLine("2. feladat: 2018-as VB csapatai:");

            for (int i = 0; i < legutobbiVB.Count; i = i + 4)
            {
                string ki = $"\t{legutobbiVB[i]}\t";
                if (legutobbiVB[i].Length < 8) ki += "\t";
                ki += $"{legutobbiVB[i + 1]}\t";
                if (legutobbiVB[i + 1].Length < 8) ki += "\t";
                ki += $"{legutobbiVB[i + 2]}\t";
                if (legutobbiVB[i + 2].Length < 8) ki += "\t";
                ki += $"{legutobbiVB[i + 3]}";

                Console.WriteLine(ki);
            }

            Console.WriteLine();
        }

        private static void F1()
        {
            Console.WriteLine($"1. feladat: csapatok száma: {orszagok.Count}\r\n");
        }

        private static void Beolvas()
        {
            var sr = new StreamReader(@"../../res/fociVBk.csv");
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                orszagok.Add(new Orszag(sr.ReadLine()));
            }

            sr.Close();
        }
    }
}
