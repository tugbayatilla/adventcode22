namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    
    [Fact]
    public void _001_get_cargo_is_null()
    {
        AdventDay5 adventDay5 = new();
        Assert.NotNull(adventDay5.GetCargoState());
    }
    
    [Fact]
    public void _002_cargo_has_one_emtpy_stack()
    {
        AdventDay5 adventDay5 = new();
        Assert.Equal(1,adventDay5.GetCargoState().Count());
    }
    
    [Fact]
    public void _003_cargo_has_one_crate_in_one_stack()
    {
        AdventDay5 adventDay5 = new();
        var firstStack = adventDay5.GetCargoState().First();
        Assert.Equal(1,firstStack.Count());
    }
}