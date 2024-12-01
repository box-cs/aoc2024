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
          .Aggregate(0, (acc, x) => acc + Math.Abs(x.First - x.Second));
    }

    public static int PartTwo(List<int> left, List<int> right)
    {
        return left.Select(value => right.FindAll(x => x == value).Count * value)
                   .Aggregate(0, (acc, x) => acc + x);
    }


    public static Tuple<List<int>, List<int>> ReadFile(string path)
    {
        var input = File.ReadAllLines(path).ToList();
        var (left, right) = (new List<int>(), new List<int>());

        foreach (var line in input)
        {
            var values = line.Split("   ");
            var (leftValue, rightValue) = (values[0], values[1]);

            _ = int.TryParse(leftValue, out int res);
            left.Add(res);
            _ = int.TryParse(rightValue, out res);
            right.Add(res);
        }

        left.Sort();
        right.Sort();
        return new(left, right);
    }
}
