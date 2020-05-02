using System;
using System.Collections.Generic;

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
