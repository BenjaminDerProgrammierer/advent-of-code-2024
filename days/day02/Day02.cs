// https://adventofcode.com/2024/day/2

namespace advent_of_code_2024
{
    public static class Day02
    {
        public static void Solve(string inputPath)
        {
            Console.WriteLine($"DAY 02 | Part 1: {Day02.Part1(File.ReadAllText(inputPath))}, Part 2: {Day02.Part2(File.ReadAllText(inputPath))}");
        }
        public static int Part1(string input)
        {
            int safes = input.Split("\n")
                                .Select(line => line.Split(" ")
                                                    .Select(int.Parse)
                                                    .ToArray())
                                .Count(level => isSafe(level));
            return safes;
        }

        public static int Part2(string input)
        {
            int safes = 0;
            int[][] reports = input.Split("\n")
                                .Select(line => line.Split(" ")
                                                    .Select(int.Parse)
                                                    .ToArray())
                                .ToArray();
            foreach (int[] level in reports)
            {
                for (int i = -1; i < level.Length; i++)
                {
                    int[] newLevel = level;
                    // remove element i from the array
                    if (i != -1)
                    {
                        newLevel = level[..i].Concat(level[(i + 1)..]).ToArray();
                    }
                    if (isSafe(newLevel))
                    {
                        safes++;
                        break;
                    }
                }
            }
            return safes;
        }

        static private bool isSafe(int[] level)
        {
            if (level[0] > level[1])
            {
                // decreasing
                for (int i = 1; i < level.Length; i++)
                {
                    if (level[i] > level[i - 1]) // suddenly increasing
                    {
                        return false;
                    }
                    if (Math.Abs(level[i - 1] - level[i]) > 3 || Math.Abs(level[i - 1] - level[i]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
                    {
                        return false;
                    }
                }
            }
            else
            {
                // increasing
                for (int i = 1; i < level.Length; i++)
                {
                    if (level[i] < level[i - 1]) // suddenly decreasing
                    {
                        return false;
                    }
                    if (Math.Abs(level[i - 1] - level[i]) > 3 || Math.Abs(level[i - 1] - level[i]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
