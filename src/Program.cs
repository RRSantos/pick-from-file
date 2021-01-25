using System;
using System.IO;
using CommandLine;

namespace PickFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed(opt =>
                   {
                       string[] extractedValues = extractValues(opt.FileName);
                       ValuesPicker vp = new ValuesPicker(extractedValues);
                       string[] picks = vp.Pick(opt.Count, opt.CanRepeatValue);

                       showPicks(picks);

                   });
        }

        private static string[] extractValues(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        private static void showPicks(string[] picks)
        {
            Console.WriteLine("\nPicked values:");
            for (int i = 0; i < picks.Length; i++)
            {
                Console.WriteLine($"{i+1}. {picks[i]}");
            }
        }
    }
}
