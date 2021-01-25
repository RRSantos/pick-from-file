using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace PickFromFile
{
    class CommandLineOptions
    {
        [Value(0, MetaName = "input file",
            HelpText = "Input file to pick values from.",
            Required = true)]
        public string FileName { get; set; }

        [Option('c', "count", Required = false, HelpText = "Count of values to pick up.", Default = 1)]
        public int Count { get; set; }

        [Option('r', "can-repeat", Required = false, HelpText = "A value can be picked more than one time?", Default = false)]
        public bool CanRepeatValue { get; set; }
    }
}
