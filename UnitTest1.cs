namespace AdventOfCode22;

public class UnitTest1
{
    [Fact]
    public void Day_Exist()
    {
        AdventDay1 adventDay1 = new();
        
        Assert.NotNull(adventDay1);
    }
    
    [Fact]
    public void Return_MostCalories_Exist()
    {
        AdventDay1 adventDay1 = new();
        
        Assert.Equal(0, adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_An_Elf_returns_the_calories()
    {
        AdventDay1 adventDay1 = new();
        adventDay1.AddCalories(100);
        
        Assert.Equal(100, adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_A_specific_Elf_returns_the_calories()
    {
        AdventDay1 adventDay1 = new();
        adventDay1.AddCalories(100, 1);
        
        Assert.Equal(100, adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_returns_most_calories()
    {
        AdventDay1 adventDay1 = new();
        adventDay1.AddCalories(100, 0);
        adventDay1.AddCalories(200, 1);
        
        Assert.Equal(200, adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_multiple_calories_returns_most_calories()
    {
        AdventDay1 adventDay1 = new();
        adventDay1.AddCalories(100, 0);
        adventDay1.AddCalories(200, 0);
        
        adventDay1.AddCalories(200, 1);
        adventDay1.AddCalories(300, 1);

        Assert.Equal(500, adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Empty_filePath_returns_zero_most_calories()
    {
        AdventDay1 adventDay1 = new();
        string fileName = "";
        string fileContent = adventDay1.ReadDataFromFile(fileName);

        Assert.Equal("", fileContent);
    }

    [Fact]
    public void Valid_file_with_1_record_returns_100_as_most_calories()
    {
        AdventDay1 adventDay1 = new();
        string fileName = "adventDay1.data";
        string fileContent = adventDay1.ReadDataFromFile(fileName);

        Assert.Equal("100", fileContent);
    }
    
    [Fact]
    public void Invalid_filePath_returns_zero_most_calories()
    {
        AdventDay1 adventDay1 = new();
        string fileName = "xyz";
        string fileContent = adventDay1.ReadDataFromFile(fileName);

        Assert.Equal("", fileContent);
    }
    
    [Fact]
    public void Use_filecontent_as_data_for_inventory()
    {
        AdventDay1 adventDay1 = new();
        string fileName = "adventDay1.data";
        string fileContent = adventDay1.ReadDataFromFile(fileName);

        adventDay1.FillInventory(fileContent);
        
        Assert.Equal(100, adventDay1.GetMostCalories());
    }

}

public class AdventDay1
{
    private readonly Dictionary<int, List<int>> _inventory = new();

    public int GetMostCalories()
    {
        if (_inventory.Count == 0) return 0;
        
        return _inventory.Values.Select(p=>p.Sum()).Max();
    }

    public void AddCalories(int calories, int indexOfElf = 0)
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
        AddCalories(int.Parse(fileContent));
    }
}