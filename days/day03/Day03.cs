// https://adventofcode.com/2024/day/3

using System.Text.RegularExpressions;

namespace advent_of_code_2024
{
    public static class Day03
    {
        public static void Solve(string inputPath)
        {
            Console.WriteLine($"DAY 03 | Part 1: {Day03.Part1(File.ReadAllText(inputPath))}, Part 2: {Day03.Part2(File.ReadAllText(inputPath))}");
        }
        public static int Part1(string input)
        {
            int result = 0;
            string pattern = @"mul\(\d+,\d+\)";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //extract the numbers
                int value1 = int.Parse(m.Value.Split("(")[1].Split(",")[0]);
                int value2 = int.Parse(m.Value.Split(",")[1].Split(")")[0]);
                result += value1 * value2;
            }
            return result;
        }

        public static int Part2(string input)
        {
            int result = 0;
            string pattern = @"mul\(\d+,\d+\)";
            string yes = "do()";
            string no = "don't()";
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                //extract the numbers
                //match next yes or no backwards
                string subInput = input.Substring(0, m.Index);
                Match yesMatch = Regex.Match(subInput, yes, RegexOptions.RightToLeft);
                Match noMatch = Regex.Match(subInput, no, RegexOptions.RightToLeft);
                bool yesBeforeNo = yesMatch.Success && (!noMatch.Success || yesMatch.Index > noMatch.Index);

                if(yesBeforeNo || (!noMatch.Success && !yesMatch.Success))
                {
                    int value1 = int.Parse(m.Value.Split("(")[1].Split(",")[0]);
                    int value2 = int.Parse(m.Value.Split(",")[1].Split(")")[0]);
                    result += value1 * value2;
                }
            }
            return result;
        }
    }
}
