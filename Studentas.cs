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
            //double p = 0;
            //var duomenys = new string[] { pav, vard };
            var duomenys = new List<string> { pav, vard };
            if (choice == Funkcijos.Vidurkis)
            {
                //p = VidurkioSkaiciavimas();
                duomenys.Add(VidurkioSkaiciavimas().ToString("0.##"));
            }
            else if (choice == Funkcijos.Mediana)
            {
                //p = MedianosSkaiciavimas();
                duomenys.Add(MedianosSkaiciavimas().ToString("0.##"));
            }
            else if (choice == Funkcijos.FailoVeiksmai)
            {
                duomenys.Add(VidurkioSkaiciavimas().ToString("0.##"));
                duomenys.Add(MedianosSkaiciavimas().ToString("0.##"));
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
            if (System.IO.File.Exists(irasas))
                {
                    naujasstudentas = FailoNuskaitymas(irasas);
                }
                else
                {
                    Console.WriteLine("Kelias ivestas neteisingai, pradekite is naujo");
                }

            Atvaizdavimas.AtvaizduotiSarasa(naujasstudentas, Funkcijos.FailoVeiksmai);
        }

        public static Studentas StudentoNuskaitymas(string irasas)
        {
            var args = irasas.Split().Where(x => !x.Equals("")).ToArray();
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


        public static List<Studentas> OrderStudents(List<Studentas> rikiavimas)
        {
            return rikiavimas.OrderBy(pagalpav => pagalpav.pav).ToList();
        }
    }
    public enum Funkcijos
    {
        Vidurkis,
        Mediana,
        FailoVeiksmai
    }

    public static class StudentuIrasymas
    {
        public static void NaujasIrasas()
        {
            string irasas;
            var StudentuIrasymas = new List<Studentas>();

            while (true)
            {
                Console.WriteLine("Irasykite pavarde, varda ir pazymius, kai baigsite rasyti dar karta spauskite 'enter'");
                Console.WriteLine("Jei norite generuoti pazymius atsitiktinai, po pavardes ir vardo iveskite norimu generuoti pazymiu skaiciu ir 'k' raide po jo, pvz '5k' ir spauskite 'enter'");
                irasas = Console.ReadLine();

                if (irasas.Length != 0)
                {
                    var duomenys = irasas.Split();
                    StudentuIrasymas.Add(new Studentas(irasas));
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Irasykite '1' Vidurkio skaiciavimui, '2' Medianos skaiciavimui");
            irasas = Console.ReadLine();
            if (irasas.Equals("1"))
            {
                Funkcijos choice = Funkcijos.Vidurkis;
                Atvaizdavimas.AtvaizduotiSarasa(StudentuIrasymas, choice);
            }
            else if (irasas.Equals("2"))
            {
                Funkcijos choice = Funkcijos.Mediana;
                Atvaizdavimas.AtvaizduotiSarasa(StudentuIrasymas, choice);
            }
            else 
            {
                Console.WriteLine("Pasirinkta neteisingai, pradekite is naujo");
            }


        }
        }
   

    public class Atvaizdavimas
        {
            public static void AtvaizduotiSarasa(List<Studentas> StudentuIrasymas, Funkcijos choice)
            {

                var studentoduomenys = new string[] { "Pavarde", "Vardas" };

            if (choice == Funkcijos.Vidurkis)
                {
                    studentoduomenys = studentoduomenys.Append("Galutinis (Vid.)").ToArray();
                }
                else if (choice == Funkcijos.Mediana)
                {
                    studentoduomenys = studentoduomenys.Append("Galutinis (Med.)").ToArray();
                }
                else if (choice == Funkcijos.FailoVeiksmai)
                {
                    studentoduomenys = studentoduomenys.Append("Galutinis (Vid.)").ToArray();
                    studentoduomenys = studentoduomenys.Append("Galutinis (Med.)").ToArray();
                }

                StudentuIrasymas = Studentas.OrderStudents(StudentuIrasymas);

                PridetiEilute(studentoduomenys);
                Console.WriteLine(Bruksniuoti());
                foreach (var Studentas in StudentuIrasymas)
                {
                   PridetiEilute(Studentas.save(choice));
                }
            }
        public static string Lygiuoti(string input, int width)
        {
            input = input.Length > width ? input.Substring(0, width - 3) + "..." : input;

            return input.PadRight(width);
        }

        public static string Bruksniuoti()
        {
            return new string('-', 100);
        }

        public static string Formatuoti(params string[] columns)
        {
            int width = 100 / columns.Length;
            string studentoduomenys = " ";

            foreach (string column in columns)
            {
                studentoduomenys += Lygiuoti(column, width);
            }

            return studentoduomenys;
        }


        public static void PridetiEilute(params string[] columns)
        {
                Console.WriteLine(Formatuoti(columns));
        }
        }
    
}
