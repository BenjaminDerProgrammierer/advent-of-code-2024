// https://adventofcode.com/2024/day/4

using System.Text.RegularExpressions;

namespace advent_of_code_2024
{
    public static class Day04
    {
        public static void Solve(string inputPath)
        {
            Console.WriteLine($"DAY 04 | Part 1: {Day04.Part1(File.ReadAllText(inputPath))}, Part 2: {Day04.Part2(File.ReadAllText(inputPath))}");
        }
        public static int Part1(string input)
        {
            int result = 0;
            string pattern = "X";
            char[][] arr = input
                .Split('\n') // Split the string by new lines
                .Select(line => line.ToCharArray()) // Convert each line to a char array
                .ToArray(); // Convert the IEnumerable<char[]> to a char[][]


            foreach (var row in arr)
            {
                Console.WriteLine(string.Join("", row));
            }

            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                //search for any (2d) surrounding Ms
                List<int[]> directions = new List<int[]>();
                int row = m.Index / arr.Length;
                int col = m.Index % arr.Length;

                if (row != 0)
                {
                    //top
                    if (arr[row - 1][col] == 'M')
                    {
                        directions.Add(new int[] { 0, -1 });
                        Console.WriteLine($"Found 'M' at (-1, 0)");
                    }
                    if (col != 0)
                    {
                        //top left
                        if (arr[row - 1][col - 1] == 'M')
                        {
                            directions.Add(new int[] { -1, -1 });
                            Console.WriteLine($"Found 'M' at (-1, -1)");
                        }
                    }
                    if (col != arr.Length - 1)
                    {
                        //top right
                        if (arr[row - 1][col + 1] == 'M')
                        {
                            directions.Add(new int[] { 1, -1 });
                            Console.WriteLine($"Found 'M' at (1, -1)");
                        }
                    }
                }
                if (row != arr.Length - 1)
                {
                    //bottom
                    if (arr[row + 1][col] == 'M')
                    {
                        directions.Add(new int[] { 0, 1 });
                        Console.WriteLine($"Found 'M' at (0, 1)");
                    }
                    if (col != 0)
                    {
                        //bottom left
                        if (arr[row + 1][col - 1] == 'M')
                        {
                            directions.Add(new int[] { -1, 1 });
                            Console.WriteLine($"Found 'M' at (-1, 1)");
                        }
                    }
                    if (col != arr.Length - 1)
                    {
                        //bottom right
                        if (arr[row + 1][col + 1] == 'M')
                        {
                            directions.Add(new int[] { 1, 1 });
                            Console.WriteLine($"Found 'M' at (1, 1)");
                        }
                    }
                }
                if (col != 0)
                {
                    //left
                    if (arr[row][col - 1] == 'M')
                    {
                        directions.Add(new int[] { -1, 0 });
                        Console.WriteLine($"Found 'M' at (0, -1)");
                    }
                }
                if (col != arr.Length - 1)
                {
                    //right
                    if (arr[row][col + 1] == 'M')
                    {
                        directions.Add(new int[] { 1, 0 });
                        Console.WriteLine($"Found 'M' at (0, +1)");
                    }
                }
                //if there are any Ms surrounding the X
                if (directions.Count > 0)
                {
                    //check if there are any As in the same directions
                    foreach (var direction in directions)
                    {
                        int newRowA = row + direction[0] * 2;
                        int newColA = col + direction[1] * 2;
                        int newRowS = row + direction[0] * 3;
                        int newColS = col + direction[1] * 3;

                        if (newRowA >= 0 && newRowA < arr.Length && newColA >= 0 && newColA < arr[0].Length && arr[newRowA][newColA] == 'A')
                        {
                            Console.WriteLine($"Found 'A'");
                            if (newRowS >= 0 && newRowS < arr.Length && newColS >= 0 && newColS < arr[0].Length && arr[newRowS][newColS] == 'S')
                            {
                                Console.WriteLine($"Found 'S'");
                                result++;
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static int Part2(string input)
        {
            int result = 0;
            // your code here
            return result;
        }
    }
}
