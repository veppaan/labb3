//Labb 3 Vera Kippel
//Gästbok som visar inlägg från användare, det går att lägga till och radera inläggen.

using System;
using System.Runtime.CompilerServices;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Guestbook guestbook = new Guestbook();
            int i;

            //Utskrift till användaren
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = true;
                Console.WriteLine("G Ä S T B O K\n");

                i = 0;
                foreach (Post post in guestbook.getPosts())
                {
                    Console.WriteLine("[" + i++ + "] " + "Gäst: " + post.Guest + " Meddelande: " + post.Message);
                }

                Console.WriteLine("\n1. Lägg till ett inlägg");
                Console.WriteLine("2. Ta bort ett inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                

                //Användarens val
                int chosenOption = (int)Console.ReadKey(true).Key;

                switch (chosenOption)
                {
                    //Lägg till ett index
                    case '1':
                        Console.CursorVisible = true;
                        Console.Write("Ange ditt namn: ");
                        string? guestName = Console.ReadLine();
                        Console.Write("Ange din text: ");
                        string? message = Console.ReadLine();
                        if (!String.IsNullOrWhiteSpace(guestName) && !String.IsNullOrWhiteSpace(message))
                        {
                            guestbook.addPost(guestName, message);
                        }
                        else
                        {
                            Console.WriteLine("Fälten får inte vara tomma! Tryck på valfri tangent för att fortsätta.");
                            Console.ReadKey();
                        }
                        break;
                    //Radera inlägg med index
                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("Ange index du vill radera: ");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                            try
                            {
                                guestbook.deletePost(Convert.ToInt32(index));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Index är ogiltig! \n Tryck på valfri knapp för att fortsätta");
                                Console.ReadKey();
                            }
                        break;
                    //Avsluta programmet, 88 är X i ASCII-värde
                    case 88:
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}