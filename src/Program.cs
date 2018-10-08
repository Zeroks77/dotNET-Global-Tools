using System;
using System.IO;
using System.Reflection;

namespace botsay
{
    class Program
    {
        
        static void Main(string[] args)
        {
           if (args.Length == 0)
            {
                var versionString = Assembly.GetEntryAssembly()
                                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                        .InformationalVersion
                                        .ToString();

                Console.WriteLine($"botsay v{versionString}");
                Console.WriteLine("-------------");
                Console.WriteLine("\nUsage:");
                Console.WriteLine("  botsay <message>");
                return;
            }      
            Asciiart.ShowBot(string.Join(' ', args));
            Console.ReadKey();
        }
  
    }

    class Asciiart
    {
    
         private static string getsrc()
        {
            Console.WriteLine("Bitte Speichere deine Asciiart im Ordner AsciiArt");
            Console.WriteLine("Wenn du eine andere Datei auswählen möchtest dann gib bitte hier den namen mit der Endung .txt an");
            Console.WriteLine("Wenn du nicht ändern möchtest gib bitte Ascii ein.");
            string rtr = Console.ReadLine();
            if(rtr == "Ascii")
            {
                return "Asciiart.txt";
            }else
                return rtr;
        }


        public static void ShowBot(string message)
        {
            string bot = $"\n        {message}";
            bot += catchascii();
            Console.WriteLine(bot);
        }
        public static string catchascii()
        {
            string asciisrc = getsrc();
            return  System.IO.File.ReadAllText($@"C:\Develop\botsay\.NET-Global-Tools\AsciiArt\{asciisrc}");
        }
    }
}
