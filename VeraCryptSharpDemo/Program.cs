using System;
using VeraCryptSharp;
using CliSharp.Exceptions;
using System.IO;

namespace VeracryptSharpDemo
{
    class Program
    {
        static bool quit = false;
        static IVeraCrypt veraCrypt;
        static string defaultVeraCryptPath = @"C:\Program Files\VeraCrypt\VeraCrypt.exe";

        static void Main(string[] args)
        {
            Console.WriteLine("*** VeraCryptSharp Command Line Library ***");
            Console.WriteLine();

            if(File.Exists(defaultVeraCryptPath))
            {
                Console.WriteLine("VeraCrypt.exe executable found.");
                veraCrypt = new VeraCrypt(defaultVeraCryptPath);
            } else
            {
                Console.Write("Enter VeraCrypt.exe absolute path: ");
                var filePath = Console.ReadLine();
                veraCrypt = new VeraCrypt(filePath);
            }

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
            Console.WriteLine("\t2) Mount secure");
            Console.WriteLine("\t3) Dismount");
            Console.WriteLine("\t4) Dismount all");
            Console.WriteLine("\t5) Quit");

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
                        MountSecureVolume();
                        break;
                    case 3:
                        DismountVolume();
                        break;
                    case 4:
                        DismountAllVolumes();
                        break;
                    case 5:
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
        private static void MountSecureVolume()
        {
            Console.Write("VeraCrypt volume path: ");
            var filePath = Console.ReadLine();

            Console.Write("Drive letter: ");
            var driveLetter = Console.ReadLine();

            try
            {
                veraCrypt.MountSecure(filePath, driveLetter: driveLetter);

                Console.WriteLine($@"Volume {driveLetter}:\ mounted.");
            }
            catch (ExitCodeException e)
            {
                Console.WriteLine(e.Message);
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
