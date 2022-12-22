namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    private readonly AdventDay5 _adventDay5 = new();

    [Fact]
    public void _001_get_cargo_is_null()
    {
        Assert.NotNull(_adventDay5.GetCargoState());
    }

    [Fact]
    public void _002_cargo_has_one_emtpy_stack()
    {
        Assert.Equal(1, _adventDay5.GetCargoState().Count());
    }

    [Fact]
    public void _003_cargo_has_one_crate_in_one_stack()
    {
        _adventDay5.AddCrateToStack(1, "");
        var firstStack = _adventDay5.GetCargoState().First();
        Assert.Equal(1, firstStack.Count());
    }

    [Fact]
    public void _004_cargo_has_two_crates_in_one_stack()
    {
        _adventDay5.AddCrateToStack(1, "");
        _adventDay5.AddCrateToStack(1, "");
        var firstStack = _adventDay5.GetCargoState().First();
        Assert.Equal(2, firstStack.Count());
    }
    
    [Fact]
    public void _005_cargo_has_one_crate_named_H_in_one_stack()
    {
        _adventDay5.AddCrateToStack(1, "H");
        var firstStack = _adventDay5.GetCargoState().First();
        var firstCrate = firstStack.First();
        Assert.Equal("H", firstCrate);
    }
}