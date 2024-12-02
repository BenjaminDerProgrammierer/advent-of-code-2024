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
            int errors = 0;
            int[][] reports = input.Split("\n")
                                .Select(line => line.Split(" ")
                                                    .Select(int.Parse)
                                                    .ToArray())
                                .ToArray();
            bool error = false;
            foreach (int[] level in reports)
            {
                if (level[0] > level[1])
                {
                    // decreasing
                    for (int i = 1; i < level.Length; i++)
                    {
                        if (level[i] > level[i - 1]) // suddenly increasing
                        {
                            error = true;
                            break;
                        }
                        if (Math.Abs(level[i - 1] - level[i]) > 3 || Math.Abs(level[i - 1] - level[i]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
                        {
                            error = true;
                            break;
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
                            error = true;
                            break;
                        }
                        if (Math.Abs(level[i - 1] - level[i]) > 3 || Math.Abs(level[i - 1] - level[i]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
                        {
                            error = true;
                            break;
                        }
                    }
                }
                if (error)
                {
                    error = false;
                    errors++;
                }
            }

            return 1000 - errors;
        }

        public static int Part2(string input)
        {
            // //Now, the same rules apply as before, except if removing a single level from an unsafe report would make it safe, the report instead counts as safe.
            // int errors = 0;
            // int[][] reports = input.Split("\n")
            //                     .Select(line => line.Split(" ")
            //                                         .Select(int.Parse)
            //                                         .ToArray())
            //                     .ToArray();
            // bool error = false;
            // for (int i = 0; i < reports.Length; i++)
            // {
            //     int[] level = reports[i];
            //     if (level[0] > level[1])
            //     {
            //         // decreasing
            //         for (int j = 1; j < level.Length; j++)
            //         {
            //             if (level[j] > level[j - 1]) // suddenly increasing
            //             {
            //                 error = true;
            //                 break;
            //             }
            //             if (Math.Abs(level[j - 1] - level[j]) > 3 || Math.Abs(level[j - 1] - level[j]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
            //             {
            //                 error = true;
            //                 break;
            //             }
            //         }
            //     }
            //     else
            //     {
            //         // increasing
            //         for (int j = 1; j < level.Length; j++)
            //         {
            //             if (level[j] < level[j - 1]) // suddenly decreasing
            //             {
            //                 error = true;
            //                 break;
            //             }
            //             if (Math.Abs(level[j - 1] - level[j]) > 3 || Math.Abs(level[j - 1] - level[j]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
            //             {
            //                 error = true;
            //                 break;
            //             }
            //         }
            //     }
            //     if (error)
            //     {
            //         error = false;
            //         // try removing one level
            //         for (int j = 0; j < level.Length; j++)
            //         {
            //             int[] newLevel = level.Where((source, index) => index != j).ToArray();
            //             if (newLevel[0] > newLevel[1])
            //             {
            //                 // decreasing
            //                 for (int k = 1; k < newLevel.Length; k++)
            //                 {
            //                     if (newLevel[k] > newLevel[k - 1]) // suddenly increasing
            //                     {
            //                         error = true;
            //                         break;
            //                     }
            //                     if (Math.Abs(newLevel[k - 1] - newLevel[k]) > 3 || Math.Abs(newLevel[k - 1] - newLevel[k]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
            //                     {
            //                         error = true;
            //                         break;
            //                     }
            //                 }
            //             }
            //             else
            //             {
            //                 // increasing
            //                 for (int k = 1; k < newLevel.Length; k++)
            //                 {
            //                     if (newLevel[k] < newLevel[k - 1]) // suddenly decreasing
            //                     {
            //                         error = true;
            //                         break;
            //                     }
            //                     if (Math.Abs(newLevel[k - 1] - newLevel[k]) > 3 || Math.Abs(newLevel[k - 1] - newLevel[k]) == 0) // Any two adjacent levels are only allowed to differ by at least one and at most three.
            //                     {
            //                         error = true;
            //                         break;
            //                     }
            //                 }
            //             }
            //             if (!error)
            //             {
            //                 reports[i] = newLevel;
            //                 break;
            //             }
            //             error = false;
            //         }
            //         errors++;
            //     }
            // }
            // return 1000 - errors;
            return 0;
        }
    }
}