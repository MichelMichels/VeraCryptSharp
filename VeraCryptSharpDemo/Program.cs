using System;
using VeraCryptSharp;
using CliSharp.Exceptions;

namespace VeracryptSharpDemo
{
    class Program
    {
        static bool quit = false;
        static IVeraCrypt veraCrypt;

        static void Main(string[] args)
        {
            Console.WriteLine("*** VeraCryptSharp Command Line Library ***");
            Console.WriteLine();

            Console.Write("Enter VeraCrypt.exe absolute path: ");
            var filePath = Console.ReadLine();
            veraCrypt = new VeraCrypt(filePath);

            do
            {
                WriteMenu();
                DoMenuAction(Console.ReadLine());
            } while (!quit);
        }
       
        private static void WriteMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("\t1) Mount");
            Console.WriteLine("\t2) Dismount");
            Console.WriteLine("\t3) Dismount all");
            Console.WriteLine("\t4) Quit");

            Console.WriteLine();
        }
        private static void DoMenuAction(string number)
        {
            if(int.TryParse(number, out int menuIndex))
            {
                switch(menuIndex)
                {
                    case 1:
                        MountVolume();
                        break;
                    case 2:
                        DismountVolume();
                        break;
                    case 3:
                        DismountAllVolumes();
                        break;
                    case 4:
                        quit = true;
                        break;
                }
            }
        }
        private static void MountVolume()
        {
            Console.Write("VeraCrypt volume path: ");
            var filePath = Console.ReadLine();

            Console.Write("Drive letter: ");
            var driveLetter = Console.ReadLine();

            Console.Write("Password: ");
            var password = Console.ReadLine();

            try
            {
                veraCrypt.Mount(filePath, password, driveLetter: driveLetter);

                Console.WriteLine($@"Volume {driveLetter}:\ mounted.");
            } catch(ExitCodeException)
            {
                Console.WriteLine("Something went wrong, try again");
            }
        }
        private static void DismountVolume()
        {
            Console.Write("Drive letter to dismount: ");
            var driveLetter = Console.ReadLine();

            veraCrypt.Dismount(driveLetter);
            Console.WriteLine($@"Volume {driveLetter}:\ dismounted.");

        }
        private static void DismountAllVolumes()
        {
            veraCrypt.DismountAll();

            Console.WriteLine("All volumes dismounted.");
        }              
    }
}
