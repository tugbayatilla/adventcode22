namespace AdventOfCode22;

public class AdventDay1UnitTests
{
    private readonly AdventCode _adventCode = new();
    private const string FileName = "Data/AdventDay1_TestData.data";

    [Fact]
    public void Day_Exist()
    {
        AdventCode adventCode = new();
        
        Assert.NotNull(adventCode);
    }
    
    [Fact]
    public void Return_MostCalories_Exist()
    {
        Assert.Equal(0, _adventCode.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_An_Elf_returns_the_calories()
    {
        _adventCode.AddCalories(100, 0);
        
        Assert.Equal(100, _adventCode.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_To_A_specific_Elf_returns_the_calories()
    {
        _adventCode.AddCalories(100, 1);
        
        Assert.Equal(100, _adventCode.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_returns_most_calories()
    {
        _adventCode.AddCalories(100, 0);
        _adventCode.AddCalories(200, 1);
        
        Assert.Equal(200, _adventCode.GetMostCalories());
    }
    
    [Fact]
    public void Add_Calories_for_2_Elves_multiple_calories_returns_most_calories()
    {
        _adventCode.AddCalories(100, 0);
        _adventCode.AddCalories(200, 0);
        
        _adventCode.AddCalories(200, 1);
        _adventCode.AddCalories(300, 1);

        Assert.Equal(500, _adventCode.GetMostCalories());
    }
    
    [Fact]
    public void Empty_filePath_returns_zero_most_calories()
    {
        string fileName = "";
        string fileContent = _adventCode.ReadDataFromFile(fileName);

        Assert.Equal("", fileContent);
    }

    [Fact]
    public void Valid_file_with_1_record_returns_100_as_most_calories()
    {
        string fileContent = _adventCode.ReadDataFromFile(FileName);

        Assert.Equal("100", fileContent);
    }
    
    [Fact]
    public void Invalid_fileName_returns_zero_most_calories()
    {
        string fileContent = _adventCode.ReadDataFromFile("xyz");

        Assert.Equal("", fileContent);
    }
    
    [Fact]
    public void Use_filecontent_as_data_for_inventory()
    {
        string fileContent = _adventCode.ReadDataFromFile(FileName);

        _adventCode.FillInventory(fileContent);
        
        Assert.Equal(100, _adventCode.GetMostCalories());
    }
    
    [Fact]
    public void File_contains_multiple_entires_for_One_Elf()
    {
        string fileContent = 
            @"100
              200";

        _adventCode.FillInventory(fileContent);
        
        Assert.Equal(300, _adventCode.GetMostCalories());
    }
    
    [Fact]
    public void File_contains_multiple_entries_for_2_Elves()
    {
        string fileContent = 
            @"100
              200

              300
              400";

        _adventCode.FillInventory(fileContent);
        
        Assert.Equal(700, _adventCode.GetMostCalories());
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

        _adventCode.FillInventory(fileContent);

        int sumOfTop3Calories = _adventCode.GetElvesAndCaloriesOrderedDesc().Take(3).Sum(p=>p.TotalCalories);
        Assert.Equal(3300, sumOfTop3Calories);
    }

}