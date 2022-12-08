namespace AdventOfCode22;

public class AdventDay1UnitTests
{
    private readonly AdventCode _adventDay1 = new();
    private const string FileName = "Day1/AdventDay1_TestData.data";

    [Fact]
    public void Day_Exist()
    {
        Assert.NotNull(_adventDay1);
    }
    
    [Fact]
    public void Return_MostCalories_Exist()
    {
        Assert.Equal(0, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_An_Elf_returns_the_calories()
    {
        _adventDay1.AddCalories(100, 0);
        
        Assert.Equal(100, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_A_specific_Elf_returns_the_calories()
    {
        _adventDay1.AddCalories(100, 1);
        
        Assert.Equal(100, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_returns_most_calories()
    {
        _adventDay1.AddCalories(100, 0);
        _adventDay1.AddCalories(200, 1);
        
        Assert.Equal(200, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_multiple_calories_returns_most_calories()
    {
        _adventDay1.AddCalories(100, 0);
        _adventDay1.AddCalories(200, 0);
        
        _adventDay1.AddCalories(200, 1);
        _adventDay1.AddCalories(300, 1);

        Assert.Equal(500, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void Empty_filePath_returns_zero_most_calories()
    {
        string fileName = "";
        string fileContent = _adventDay1.ReadDataFromFile(fileName);

        Assert.Equal("", fileContent);
    }

    [Fact]
    public void Valid_file_with_1_record_returns_100_as_most_calories()
    {
        string fileContent = _adventDay1.ReadDataFromFile(FileName);

        Assert.Equal("100", fileContent);
    }
    
    [Fact]
    public void Invalid_fileName_returns_zero_most_calories()
    {
        string fileContent = _adventDay1.ReadDataFromFile("xyz");

        Assert.Equal("", fileContent);
    }
    
    [Fact]
    public void Use_filecontent_as_data_for_inventory()
    {
        string fileContent = _adventDay1.ReadDataFromFile(FileName);

        _adventDay1.FillInventory(fileContent);
        
        Assert.Equal(100, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void File_contains_multiple_entires_for_One_Elf()
    {
        string fileContent = 
            @"100
              200";

        _adventDay1.FillInventory(fileContent);
        
        Assert.Equal(300, _adventDay1.GetMostCalories());
    }
    
    [Fact]
    public void File_contains_multiple_entries_for_2_Elves()
    {
        string fileContent = 
            @"100
              200

              300
              400";

        _adventDay1.FillInventory(fileContent);
        
        Assert.Equal(700, _adventDay1.GetMostCalories());
    }

    [Fact]
    public void Get_top_3_most_calories()
    {
        string fileContent = 
            @"100
              200

              300
              400

              500
              600

              700
              800";

        _adventDay1.FillInventory(fileContent);

        int sumOfTop3Calories = _adventDay1.GetElvesAndCaloriesOrderedDesc().Take(3).Sum(p=>p.TotalCalories);
        Assert.Equal(3300, sumOfTop3Calories);
    }
    
}