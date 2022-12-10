namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    
    [Fact]
    public void _001_get_cargo_is_null()
    {
        AdventDay5 adventDay5 = new();
        Assert.NotNull(adventDay5.GetCargoState());
    }

}