using System;

namespace duomenuapdorojimas
{
    class Paleidimas
    {
        static void Main(string[] args)
        {
         while (true){
                Console.WriteLine("Spauskite bet kuri klavisa norint irasyti studenta, tada spauskite 'enter'");
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
