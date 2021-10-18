using System;
using System.Collections.Generic;
using Matcher.Business;
using static System.Console;

namespace Matcher.App
{
    using regex = Matcher.Business.SimpleRegex;
    using distance = Matcher.Business.LevenshteinAlgo;

    class Program
    {
        static void Main(string[] args) {
            string input = "";
            while (input != "exit") {
                switch(input = ReadLine()) {
                    case "regex":
                        Write("input string: ");
                        input = ReadLine();

                        Write("input pattern to match: ");
                        WriteLine(regex.IsMatch(input, ReadLine()));
                        break;
                    case "regex2":
                        Write("input string: ");
                        input = ReadLine();

                        Write("input pattern to match: ");
                        WriteLine(regex.IsMatchRecursive(input, ReadLine()));
                        break;
                    case "distance":
                        Write("input string: ");
                        input = ReadLine();

                        Write("input string2: ");
                        WriteLine(distance.LevenshteinDistance(input, ReadLine()));
                        break;
                    case "exit": break;
                    default: break;
                }
            }

        }
    }
}
