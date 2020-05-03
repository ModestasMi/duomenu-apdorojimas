using duomenuapdorojimas;
using System;
using System.Collections.Generic;
using System.Linq;

public class Atvaizdavimas
{
    public static int tableWidth = 80;

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