namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    
    [Fact]
    public void You_can_get_current_cargo_state()
    {
        AdventDay5 adventDay5 = new();
        Assert.NotNull(adventDay5.GetCurrentCargoState());
    }
    
    [Fact]
    public void cargo_state_contains_list_of_stack()
    {
        AdventDay5 adventDay5 = new();
        Assert.IsAssignableFrom<IEnumerable<object>>(adventDay5.GetCurrentCargoState());
    }
    
    [Fact]
    public void first_stack_contains_one_crate_named_Z()
    {
        AdventDay5 adventDay5 = new();
        Assert.Equal("Z",adventDay5.GetCurrentCargoState().First());
    }

}