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
                Console.WriteLine("Iveskite 'gen' norint sugeneruoti sarasus");
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
                    break;
                }
                else
                {
                    StudentuIrasymas.NaujasIrasas();
                }
            }
        }
    }
}
