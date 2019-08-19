using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace commandlineParser_demo
{
    class Program
    {
        [Verb("add", HelpText = "add file contents to your file")]
        class AddOptions
        {

        }
        public class Options
        {
            //    commandlineParser-demo -r test1.txt test2.json
            //or, commandlineParser-demo --read test1.txt test2.json
            [Option('r', "read", Required = true, HelpText = "input files to be processed")]
            public IEnumerable<string> InputFiles { get; set; }

            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                //.MapResult((AddOptions opts) => RunAdd(opts),(parseErrors)=>1)

                .WithParsed<Options>(opts => RunOptions(opts))
                ;


        }
        static int RunAdd(AddOptions opts)
        {

            return 0;
        }

        static void NotMapped(IEnumerable<Error> errs)
        {

        }

        static void RunOptions(Options opts)
        {
            if (opts.Verbose)
            {
                Console.WriteLine($"Verbose output enabled. Current Arguments: -v {opts.Verbose}");
                Console.WriteLine("App is in verbose mode!");
            }
            if (opts.InputFiles.Count<string>() > 0)
            {
                int i = 0;
                foreach (string inputfile in opts.InputFiles)
                {
                    i = i + 1;
                    Console.WriteLine($"input file {i}: {inputfile}");
                }
            }

        }
    }
}
