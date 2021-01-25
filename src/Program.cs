using System;
using System.IO;
using CommandLine;

namespace PickFromFile
{
    class Program
    {
        private const int ONE_SECOND_IN_MILLISECONDS = 1000;
        private const string PICKING_VALUES = "Picking {0} values from file.\n";
        private const string PICKED = "\nPicked values:";
        private const string READING_VALUES_FROM_FILE = "Reading values from file {0}. ";
        private const string FOUND_VALUES = "Found a total of {0} values to pick from.";

        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<CommandLineOptions>(args)
                .WithParsed(opt =>
                   {
                       string[] extractedValues = extractValues(opt.FileName, opt.ValueSeparators);
                       ValuesPicker vp = new ValuesPicker(extractedValues);
                       Console.WriteLine(string.Format(PICKING_VALUES, opt.Count));
                       string[] picks = vp.Pick(opt.Count, opt.CanRepeatValue);
                       showPicks(picks, opt.DelayToShowEachValue);

                   });
        }

        private static string[] extractValues(string fileName, string valueSeparators)
        {
            Console.WriteLine(string.Format(READING_VALUES_FROM_FILE, fileName));
            
            string fileContent = File.ReadAllText(fileName);
            char[] separators = valueSeparators.ToCharArray();
            string[] values = fileContent.Split(separators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            
            Console.WriteLine(string.Format(FOUND_VALUES, values.Length));

            return values;


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
