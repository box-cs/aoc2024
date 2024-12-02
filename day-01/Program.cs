class Program
{
    public static void Main()
    {
        var (left, right) = ReadFile("test.txt");
        Console.WriteLine(PartOne(left, right));
        Console.WriteLine(PartTwo(left, right));
    }

    public static int PartOne(List<int> left, List<int> right)
    {
        return Enumerable.Zip(left, right)
            .Aggregate(0, (sum, x) => sum + Math.Abs(x.First - x.Second));
    }

    public static int PartTwo(List<int> left, List<int> right)
    {
        return left.Aggregate(0, (sum, x) => sum + right.FindAll(y => x == y).Count * x);
    }


    public static Tuple<List<int>, List<int>> ReadFile(string path)
    {
        var input = File.ReadAllLines(path).ToList();
        var (left, right) = (new List<int>(), new List<int>());

        input.ForEach(line =>
        {
            var values = line.Split("   ").Select(int.Parse).ToList();
            left.Add(values[0]);
            right.Add(values[1]);
        });

        left.Sort();
        right.Sort();
        return new(left, right);
    }
}
