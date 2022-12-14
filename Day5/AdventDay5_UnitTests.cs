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
    public void add_two_crate_to_first_stack_with_order_Z_and_N_then_pop_out_with_order_N_and_Z()
    {
        AdventDay5 adventDay5 = new();
        adventDay5.AddCrateToStack(1, "Z");
        adventDay5.AddCrateToStack(1, "N");
        
        Assert.Equal("N",adventDay5.GetCurrentCargoState()[0].Pop());
        Assert.Equal("Z",adventDay5.GetCurrentCargoState()[0].Pop());
    }
    
    [Fact]
    public void cargo_has_two_stacks_and_first_has_2_and_second_has_3_crates()
    {
        AdventDay5 adventDay5 = new();

        adventDay5.AddCrateToStack(1, "Z");
        adventDay5.AddCrateToStack(1, "N");
        
        adventDay5.AddCrateToStack(2, "M");
        adventDay5.AddCrateToStack(2, "C");
        adventDay5.AddCrateToStack(2, "D");
        
        Assert.Equal(2,adventDay5.GetCurrentCargoState()[0].Count);
        Assert.Equal(3,adventDay5.GetCurrentCargoState()[1].Count);
        
    }
    
}