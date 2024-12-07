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
            char[][] arr = input
                .Split('\n') // Split the string by new lines
                .Select(line => line.ToCharArray()) // Convert each line to a char array
                .ToArray(); // Convert the IEnumerable<char[]> to a char[][]

            // look for X
            for (int y = 0; y < arr.Length; y++)
            {
                char[] row = arr[y];
                for (int x = 0; x < row.Length; x++)
                {
                    char c = row[x];
                    if (c == 'X')
                    {

                        // search for Ms
                        IEnumerable<int[]> mMatches = GetSurroundingChars(x, y, arr, 'M');
                        foreach (var match in mMatches)
                        {
                            // search for A
                            int[]? direction = CheckDirection(x + match[0] * 2, y + match[1] * 2, match[0], match[1], arr, 'A');
                            if (direction != null)
                            {
                                // search for S
                                direction = CheckDirection(x + match[0] * 3, y + match[1] * 3, match[0], match[1], arr, 'S');
                                if (direction != null)
                                {
                                    result++;
                                }
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
            char[][] arr = input
                .Split('\n') // Split the string by new lines
                .Select(line => line.ToCharArray()) // Convert each line to a char array
                .ToArray(); // Convert the IEnumerable<char[]> to a char[][]
                            
            // You misunderstood the task, you should not find XMAS in any direction, you soulf find an x out of MAS
            // M.S
            // .A.
            // M.S

            // M.M
            // .A.
            // s.S

            // S.S
            // .A.
            // M.M

            // M.S
            // .A.
            // M.S

            // look for A
            for (int y = 0; y < arr.Length; y++)
            {
                char[] row = arr[y];
                for (int x = 0; x < row.Length; x++)
                {
                    char c = row[x];
                    if (c == 'A')
                    {
                        // search for the pattern
                        if (
                            (
                                CheckDirection(x - 1, y - 1, -1, -1, arr, 'M') != null && // top-left
                                CheckDirection(x + 1, y - 1, 1, -1, arr, 'S') != null && // top-right
                                CheckDirection(x - 1, y + 1, -1, 1, arr, 'M') != null && // bottom-left
                                CheckDirection(x + 1, y + 1, 1, 1, arr, 'S') != null // bottom-right
                            ) || (
                                CheckDirection(x - 1, y - 1, -1, -1, arr, 'M') != null && // top-left
                                CheckDirection(x + 1, y - 1, 1, -1, arr, 'M') != null && // top-right
                                CheckDirection(x - 1, y + 1, -1, 1, arr, 'S') != null && // bottom-left
                                CheckDirection(x + 1, y + 1, 1, 1, arr, 'S') != null // bottom-right
                            ) || (
                                CheckDirection(x - 1, y - 1, -1, -1, arr, 'S') != null && // top-left
                                CheckDirection(x + 1, y - 1, 1, -1, arr, 'S') != null && // top-right
                                CheckDirection(x - 1, y + 1, -1, 1, arr, 'M') != null && // bottom-left
                                CheckDirection(x + 1, y + 1, 1, 1, arr, 'M') != null // bottom-right
                            ) || (
                                CheckDirection(x - 1, y - 1, -1, -1, arr, 'S') != null && // top-left
                                CheckDirection(x + 1, y - 1, 1, -1, arr, 'M') != null && // top-right
                                CheckDirection(x - 1, y + 1, -1, 1, arr, 'S') != null && // bottom-left
                                CheckDirection(x + 1, y + 1, 1, 1, arr, 'M') != null // bottom-right
                            )
                        )
                        {
                            result++;
                        }
                    }
                }
            }
            return result;
        }

        private static List<int[]> GetSurroundingChars(int x, int y, char[][] arr, char searchChar)
        {
            List<int[]> directions = new List<int[]>();

            // Check all 8 directions, if the character is found (not null), add the direction to the list
            var direction = CheckDirection(x, y - 1, 0, -1, arr, searchChar);  // top
            if (direction != null) directions.Add(direction);
            direction = CheckDirection(x - 1, y - 1, -1, -1, arr, searchChar); // top-left
            if (direction != null) directions.Add(direction);
            direction = CheckDirection(x + 1, y - 1, 1, -1, arr, searchChar);  // top-right
            if (direction != null) directions.Add(direction);
            direction = CheckDirection(x, y + 1, 0, 1, arr, searchChar);       // bottom
            if (direction != null) directions.Add(direction);
            direction = CheckDirection(x - 1, y + 1, -1, 1, arr, searchChar);  // bottom-left
            if (direction != null) directions.Add(direction);
            direction = CheckDirection(x + 1, y + 1, 1, 1, arr, searchChar);   // bottom-right
            if (direction != null) directions.Add(direction);
            direction = CheckDirection(x - 1, y, -1, 0, arr, searchChar);      // left
            if (direction != null) directions.Add(direction);
            direction = CheckDirection(x + 1, y, 1, 0, arr, searchChar);       // right
            if (direction != null) directions.Add(direction);

            return directions;
        }

        private static int[]? CheckDirection(int x, int y, int dx, int dy, char[][] arr, char searchChar)
        {
            try
            {
                if (arr[y][x] == searchChar)
                {
                    return new int[] { dx, dy };
                }
            }
            catch (IndexOutOfRangeException)
            {
                // Ignore IndexOutOfRangeException
            }
            return null;
        }
    }
}
