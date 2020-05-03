using duomenuapdorojimas;
using System;
using System.Collections.Generic;
using System.Linq;

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