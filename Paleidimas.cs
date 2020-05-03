using System;

namespace duomenuapdorojimas
{
    class Paleidimas
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Spauskite 'enter' noredami irasyti studenta");
                Console.WriteLine("Iveskite 'file' norint nuskaityti duomenis is failo");
                Console.WriteLine("Iveskite 'gen' norint sugeneruoti List tipo sarasus");
                Console.WriteLine("Iveskite 'test' norint palyginti List, LinkedList ir Queue duomenų tipo greičius");
                Console.WriteLine("Iveskite 'exit' norint baigti programa");

                var irasas = Console.ReadLine();
                if (irasas.Equals("exit"))
                {
                    break;
                }
                else if (irasas.Equals("file"))
                {
                    Studentas.KelioIvedimas();
                }
                else if (irasas.Equals("gen"))
                {
                    Analize.Analizuoti();
                }
                else if (irasas.Equals("test"))
                {
                    Analize.Testavimas(100000);
                }
                else
                {
                    StudentuIrasymas.NaujasIrasas();
                }
            }
        }

    }
}
