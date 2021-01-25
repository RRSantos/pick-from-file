using System;
using System.IO;
using CommandLine;

namespace PickFromFile
{
    class Program
    {
        private const int ONE_SECOND_IN_MILLISECONDS = 1000;
        private const string PICKING_VALUES = "\nPicking {0} values from {1}...\n";
        private const string PICKED = "\nPicked values:";

        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed(opt =>
                   {
                       string[] extractedValues = extractValues(opt.FileName);
                       ValuesPicker vp = new ValuesPicker(extractedValues);
                       Console.WriteLine(string.Format(PICKING_VALUES, opt.Count, opt.FileName));
                       string[] picks = vp.Pick(opt.Count, opt.CanRepeatValue);
                       showPicks(picks, opt.DelayToShowEachValue);

                   });
        }

        private static string[] extractValues(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        private static void showPicks(string[] picks, int delayToShowEachValue)
        {   

            Console.WriteLine(PICKED);
            for (int i = 0; i < picks.Length; i++)
            {
                System.Threading.Thread.Sleep(delayToShowEachValue * ONE_SECOND_IN_MILLISECONDS);
                Console.WriteLine($"\t{i+1}. {picks[i]}");
            }
        }
    }
}
