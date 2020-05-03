using System;
using System.Collections.Generic;
using System.Linq;

namespace duomenuapdorojimas
{
    

    public class Studentas
    {
        public string vard;
        public string pav;
        List<double> pazymys = new List<double>();
        public double egpazymys;
        public static Random AtsitiktinisSk = new Random();


       

        public Studentas(string vardas, string pavarde)
        {
            vard = vardas;
            pav = pavarde;
        }

        public Studentas(string vardas, string pavarde, List<double> ivertinimai)
        {
            pazymys = ivertinimai;
        }

        public Studentas(string vardas, string pavarde, List<double> ivertinimai, double egzGrade) : this(vardas, pavarde, ivertinimai)
        {
            egpazymys = egzGrade;
        }

        public double VidurkioSkaiciavimas()
        {
            if (pazymys.Count == 0)
            {
                return 0;
            }
            else
            {
                return (double)pazymys.Sum() / (double)pazymys.Count;
            }
        }

        public double MedianosSkaiciavimas()
        {
            double[] sk = pazymys.ToArray();
            Array.Sort(sk);
            int pazymiusk = sk.Length;

            if (pazymiusk % 2 == 0)
            {
                return (sk[pazymiusk / 2] + sk[pazymiusk / 2 - 1]) / 2;
            }
            else if (pazymiusk != 0 && pazymiusk % 2 != 0)
            {
                return sk[pazymiusk / 2];
            }
            else
            {
                return 0;
            }
        }

        public Studentas(string args)
        {
            var duomenys = args.Split();
            pav = duomenys[0];
            vard = duomenys[1];

            
            if (duomenys[2].EndsWith("k"))
            {
                for (int i = 0; i < int.Parse(duomenys[2].Replace("k", "")); i++)
                {
                    pazymys.Add(AtsitiktinisSk.Next(1, 10));
                }
            }
            else
            {
                for (int i = 2; i < duomenys.Length; i++)
                {
                    pazymys.Add(double.Parse(duomenys[i]));
                }
            }
            
            
        }

        public string[] save(Funkcijos choice)
        {
            var duomenys = new List<string> { pav, vard };
            if (choice == Funkcijos.Vidurkis)
            {
                duomenys.Add(VidurkioSkaiciavimas().ToString("0.##"));
            }
            else if (choice == Funkcijos.Mediana)
            {
                duomenys.Add(MedianosSkaiciavimas().ToString("0.##"));
            }
            else if (choice == Funkcijos.FailoVeiksmai)
            {
                duomenys.Add(VidurkioSkaiciavimas().ToString("0.##"));
                duomenys.Add(MedianosSkaiciavimas().ToString("0.##"));
            }
            else if (choice == Funkcijos.IrasytiPazymius)
            {
                foreach (var paz in pazymys)
                {
                    duomenys.Add(paz.ToString("0.##"));
                }
            }
            return duomenys.ToArray();
        }
        public void PridetiEgzamina(double egzaminas)
        {
            egpazymys = egzaminas;
        }
        public void PridetiPazymi(double naujaspazymys)
        {
            pazymys.Add(naujaspazymys);
        }

        public static void KelioIvedimas()
        {
            Console.WriteLine("Failo kelio ivedimas:");
                
                var irasas = Console.ReadLine().Replace("\"", "");
                var naujasstudentas = new List<Studentas>();

            try
            {
                naujasstudentas = FailoNuskaitymas(irasas);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Klaidos pranešimas: {e.Message}");
            }
            Atvaizdavimas.AtvaizduotiSarasa(naujasstudentas, Funkcijos.FailoVeiksmai);
        }

        public static Studentas StudentoNuskaitymas(string irasas)
        {
            var args = irasas.Split().Where(laikas => !laikas.Equals("")).ToArray();
            var studentas = new Studentas(args[0], args[1]);
            int i = 2;
            while(i < args.Length - 1)
            {      
                studentas.PridetiPazymi(double.Parse(args[i]));
                i++;
            }
            studentas.PridetiEgzamina(double.Parse(args.Last()));

            return studentas;
        }

        public static List<Studentas> FailoNuskaitymas(string path)
        {
            var naujasstudentas = new List<Studentas>();

            foreach (string irasas in System.IO.File.ReadLines(path).Skip(1))
            {
                naujasstudentas.Add(StudentoNuskaitymas(irasas));
            }

            return naujasstudentas;
        }

        
        public static IEnumerable<Studentas> OrderStudents(IEnumerable<Studentas> rikiavimas)
        {
            return rikiavimas.OrderBy(pagalpav => pagalpav.pav).ToList();
        }

    }
    public enum Funkcijos
    {
        Vidurkis,
        Mediana,
        FailoVeiksmai,
        IrasytiPazymius
    }


    class Analize
    {
        public static void Analizuoti()
        {

            var sizes = new List<int>() {1000, 10000, 100000, 1000000, 10000000};

            System.Console.WriteLine(Atvaizdavimas.Formatuoti("Studentu #", "Pridejimas", "Rusiavimas", "Paskirstymas", "Failu generavimas"));
            System.Console.WriteLine(Atvaizdavimas.Bruksniuoti());
            foreach (var i in sizes)
            {
                var laikomatavimas = MatuotiLaika(i);
                var timestamp = new List<string>() { $"{i}" };

                timestamp.AddRange(laikomatavimas.Select(laikas => string.Format("{0}:{1:00}.{2}", (int)laikas.TotalMinutes, laikas.Seconds, laikas.Milliseconds)));
                System.Console.WriteLine(Atvaizdavimas.Formatuoti(timestamp.ToArray()));
            }
        }

        public static List<TimeSpan> MatuotiLaika(int ilgis)
        {
            var laikotarpas = new System.Diagnostics.Stopwatch();
            var laikomatavimas = new List<TimeSpan>();

            laikotarpas.Start();

            var Studentas = new List<Studentas>();
            for (int i = 0; i < ilgis; i++)
            {
                Studentas.Add(new Studentas($"Pavarde{i} Vardas{i} 5k"));
            }

            laikomatavimas.Add(laikotarpas.Elapsed);

            StudentuIrasymas.OrderStudents(Studentas).ToList();

            laikomatavimas.Add(laikotarpas.Elapsed);

            var kietiakas = new List<Studentas>();
            var vargsiukas = new List<Studentas>();

            for (int i = 0; i < ilgis; i++)
            {
                if (Studentas[i].VidurkioSkaiciavimas() >= 5)
                {
                    kietiakas.Add(Studentas[i]);
                    
                }
                else
                {
                    vargsiukas.Add(Studentas[i]);
                }
            }

            laikomatavimas.Add(laikotarpas.Elapsed);

            string path = System.IO.Path.GetTempFileName();
            StudentuIrasymas.StudentuGeneravimas(path, vargsiukas);
            System.Console.WriteLine(path);
            System.Console.WriteLine("vargsiuku sarasas");

            path = System.IO.Path.GetTempFileName();
            StudentuIrasymas.StudentuGeneravimas(path, kietiakas);
            System.Console.WriteLine(path);
            System.Console.WriteLine("kietiaku sarasas");

            laikomatavimas.Add(laikotarpas.Elapsed);

            return laikomatavimas;

        }

            public static void Testavimas(int size)
            {

                System.Console.WriteLine($"Student list size: {size}");
                System.Console.WriteLine(Atvaizdavimas.Formatuoti("Konteineris", "Pridejimas", "Paskirstymas", "Rusiavimas", "Irasymas"));
                System.Console.WriteLine(Atvaizdavimas.Bruksniuoti());

                System.Console.WriteLine(Atvaizdavimas.Formatuoti(FormatTimeSpans(ListGreitis(size)).Prepend("List").ToArray()));
                System.Console.WriteLine(Atvaizdavimas.Formatuoti(FormatTimeSpans(LinkedListGreitis(size)).Prepend("LinkedList").ToArray()));
                System.Console.WriteLine(Atvaizdavimas.Formatuoti(FormatTimeSpans(QueueGreitis(size)).Prepend("Queue").ToArray()));
            }

            public static string[] FormatTimeSpans(List<TimeSpan> laikomatavimas)
            {
                return laikomatavimas.Select(laikas => string.Format("{0}:{1:00}.{2}", (int)laikas.TotalMinutes, laikas.Seconds, laikas.Milliseconds)).ToArray();
            }

            public static List<TimeSpan> ListGreitis(int size)
            {
                var laikomatavimas = new List<TimeSpan>();
                var laikotarpas = new System.Diagnostics.Stopwatch();
                laikotarpas.Start();

                var tipas = new List<Studentas>();
                for (int i = 0; i < size; i++)
                {
                    tipas.Add(new Studentas($"Pavarde{i} Vardas{i} 5k"));
                }

                laikomatavimas.Add(laikotarpas.Elapsed);
                var kietiakas = new List<Studentas>();
                var vargsiukas = new List<Studentas>();

                for (int i = 0; i < size; i++)
                {
                    if (tipas[i].VidurkioSkaiciavimas() >= 5)
                    {
                           kietiakas.Add(tipas[i]);
                    }
                    else
                    {
                           vargsiukas.Add(tipas[i]);
                    }
                }

                laikomatavimas.Add(laikotarpas.Elapsed);
                kietiakas = new List<Studentas>(StudentuIrasymas.OrderStudents(kietiakas));
                vargsiukas = new List<Studentas>(StudentuIrasymas.OrderStudents(vargsiukas));

                laikomatavimas.Add(laikotarpas.Elapsed);

                string path = System.IO.Path.GetTempFileName();
                StudentuIrasymas.StudentuGeneravimas(path, tipas);

                laikomatavimas.Add(laikotarpas.Elapsed);

                return laikomatavimas;
            }

        public static List<TimeSpan> LinkedListGreitis(int size)
        {
            var laikomatavimas = new List<TimeSpan>();
            var laikotarpas = new System.Diagnostics.Stopwatch();
            laikotarpas.Start();

            var tipas = new LinkedList<Studentas>();
            for (int i = 0; i < size; i++)
            {
                tipas.AddFirst(new Studentas($"Pavarde{i} Vardas{i} 5k"));
            }

            laikomatavimas.Add(laikotarpas.Elapsed);

            laikotarpas.Restart();

            var kietiakas = new LinkedList<Studentas>();
            var vargsiukas = new LinkedList<Studentas>();

            for (int i = 0; i < size; i++)
            {
                var element = tipas.First();
                if (element.VidurkioSkaiciavimas() >= 5)
                {
                    kietiakas.AddFirst(element);

                }
                else
                {
                    vargsiukas.AddFirst(element);
                }
                tipas.RemoveFirst();
            }

            laikomatavimas.Add(laikotarpas.Elapsed);

            laikotarpas.Restart();
            kietiakas = new LinkedList<Studentas>(StudentuIrasymas.OrderStudents(kietiakas));
            vargsiukas = new LinkedList<Studentas>(StudentuIrasymas.OrderStudents(vargsiukas));

            laikomatavimas.Add(laikotarpas.Elapsed);
            laikotarpas.Restart();

            string path = System.IO.Path.GetTempFileName();
            StudentuIrasymas.StudentuGeneravimas2(path, tipas);

            laikomatavimas.Add(laikotarpas.Elapsed);

            return laikomatavimas;
        }

        public static List<TimeSpan> QueueGreitis(int size)
            {
                var laikomatavimas = new List<TimeSpan>();
                var laikotarpas = new System.Diagnostics.Stopwatch();
                laikotarpas.Start();

            var tipas = new Queue<Studentas>();
            for (int i = 0; i < size; i++)
            {
                tipas.Enqueue(new Studentas($"Pavarde{i} Vardas{i} 5k"));
            }

            laikomatavimas.Add(laikotarpas.Elapsed);

            var kietiakas = new Queue<Studentas>();
            var vargsiukas = new Queue<Studentas>();

            for (int i = 0; i < size; i++)
            {
                if (tipas.ElementAt(i).VidurkioSkaiciavimas() >= 5)
                {
                    kietiakas.Enqueue(tipas.ElementAt(i));
                }
                else
                {
                    vargsiukas.Enqueue(tipas.ElementAt(i));
                }
            }

            laikomatavimas.Add(laikotarpas.Elapsed);

            kietiakas = new Queue<Studentas>(StudentuIrasymas.OrderStudents(kietiakas));
            vargsiukas = new Queue<Studentas>(StudentuIrasymas.OrderStudents(vargsiukas));

            laikomatavimas.Add(laikotarpas.Elapsed);

            string path = System.IO.Path.GetTempFileName();
            StudentuIrasymas.StudentuGeneravimas3(path, tipas);

            laikomatavimas.Add(laikotarpas.Elapsed);

            return laikomatavimas;
            }
        }


    }
