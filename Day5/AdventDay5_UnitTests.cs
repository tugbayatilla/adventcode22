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
}