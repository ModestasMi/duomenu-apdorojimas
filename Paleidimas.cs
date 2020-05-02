using System;

namespace duomenuapdorojimas
{
    class Paleidimas
    {
        static void Main(string[] args)
        {
         while (true){
                Console.WriteLine("Spauskite 'enter' noredami irasyti studenta");
                Console.WriteLine("Iveskite 'exit' norint baigti programa");

                var irasas = Console.ReadLine();
                if (irasas.Equals("exit")){
                    break; 
                }
                else{
                    Studentas.NaujasIrasas();
                }
            }
        }
    }
}
