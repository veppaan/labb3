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
            int i = 0;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("G Ä S T B O K\n");

                Console.WriteLine("1. Lägg till ett inlägg");
                Console.WriteLine("2. Ta bort ett inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                i = 0;
                foreach (Post post in guestbook.getPosts())
                {
                    Console.WriteLine("[" + i++ + "]" + "Gäst: " + post.Guest + "Text: " + post.Message);
                }
            }
        }
    }
}