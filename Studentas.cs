using System;
using System.Collections.Generic;
using System.Linq;

namespace duomenuapdorojimas

   public class Studentas 
    {
        public string vard;
        public string pav;
        List<double> pazymys = new List<double>();
        public double egpazymys;
        
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
     }
        public double VidurkioSkaiciavimas()
        {
            if(pazymys.Count == 0)
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

            for (int i = 2; i < duomenys.Length; i++)
            {
                pazymys.Add(double.Parse(duomenys[i]));
            }
        }

        public string[] save(Funkcijos choice)
        {
            double p = 0;
            var duomenys = new string[] { pav, vard };

            if (choice == Funkcijos.Vidurkis)
            {
                p = VidurkioSkaiciavimas();
            }
            else if (choice == Funkcijos.Mediana)
            {
                p = MedianosSkaiciavimas();
            }
            return duomenys.Append(p.ToString("0.##")).ToArray();
        }
    }
    public enum Funkcijos
    {
        Vidurkis,
        Mediana
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
            }
            else if (irasas.Equals("2"))
            {
                Funkcijos choice = Funkcijos.Mediana;
            }
            else 
            {
                Console.WriteLine("Pasirinkta neteisingai, pradekite is naujo");
            }


        }
        }
