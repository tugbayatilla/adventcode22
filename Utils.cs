namespace AdventOfCode22;

public static class AdventUtils
{
    public static IEnumerable<string> ReadDataFromAFile(string fileName)
    {
        var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        var path = Path.Combine(directory, fileName);

        return File.ReadAllText(path).Split(Environment.NewLine);
    }
}