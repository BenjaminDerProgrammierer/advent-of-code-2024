namespace advent_of_code_2024
{
    public static class Day01
    {
        public static void Solve(string inputPath)
        {
            Console.WriteLine($"DAY 01 | Part 1: {Day01.Part1(File.ReadAllText(inputPath))}, Part 2: {Day01.Part2(File.ReadAllText(inputPath))}");
        }
        public static int Part1(string input)
        {
            string[] lines = input.Split("\n");
            int result = 0;

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            foreach (string line in lines)
            {
                list1.Add(int.Parse(line.Split("   ")[0]));
                list2.Add(int.Parse(line.Split("   ")[1]));
            }
            list1.Sort();
            list2.Sort();

            for (int i = 0; i < list1.Count; i++)
            {
                result += list1[i] > list2[i] ?
                    list1[i] - list2[i] :
                    list2[i] - list1[i];
            }

            return result;
        }

        public static int Part2(string input)
        {
            string[] lines = input.Split("\n");
            int result = 0;

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            foreach (string line in lines)
            {
                list1.Add(int.Parse(line.Split("   ")[0]));
                list2.Add(int.Parse(line.Split("   ")[1]));
            }
            list1.Sort();
            list2.Sort();

            for (int i = 0; i < list1.Count; i++)
            {
                // find all occurrences of the same number in list2
                int count = list2.Count(x => x == list1[i]);
                result += count * list1[i];
            }

            return result;
        }
    }
}