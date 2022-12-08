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
}