namespace AdventOfCode22.Day1;

public class AdventCode
{
    private readonly Dictionary<int, List<int>> _inventory = new();

    public int GetMostCalories()
    {
        if (_inventory.Count == 0) return 0;

        return _inventory.Values.Select(p => p.Sum()).Max();
    }

    public void AddCalories(int calories, int indexOfElf)
    {
        if (!_inventory.ContainsKey(indexOfElf))
        {
            _inventory.Add(indexOfElf, new List<int>());
        }

        _inventory[indexOfElf].Add(calories);
    }

    public string ReadDataFromFile(string fileName)
    {
        if (string.IsNullOrEmpty(fileName)) return "";

        var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        var path = System.IO.Path.Combine(directory, fileName);

        if (!File.Exists(path)) return "";

        return File.ReadAllText(path);
    }

    public void FillInventory(string fileContent)
    {
        var emptyLine = Environment.NewLine + Environment.NewLine;
        var elfInventories = fileContent.Split(emptyLine);
        for (var indexOfElf = 0; indexOfElf < elfInventories.Length; indexOfElf++)
        {
            var elfInventory = elfInventories[indexOfElf];
            var items = elfInventory.Split(Environment.NewLine);

            foreach (var item in items)
            {
                AddCalories(int.Parse(item), indexOfElf);
            }
        }
    }

    public IEnumerable<(int ElfIndex, int TotalCalories)> GetElvesAndCaloriesOrderedDesc() 
        => _inventory.Select(item => (item.Key, item.Value.Sum()))
            .OrderByDescending(p=>p.Item2);

}