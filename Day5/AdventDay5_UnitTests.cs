namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    private readonly AdventDay5 _adventDay5 = new();

    [Fact(Skip = "GetCargoState is removed")]
    public void _001_get_cargo_is_null()
    {
        Assert.True(true);
    }

    [Fact]
    public void _002_cargo_has_one_emtpy_stack()
    {
        var stackId = _adventDay5.GetCargo().AddStack();
        var stack = _adventDay5.GetCargo().GetStackById(stackId);
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void _003_cargo_has_one_crate_in_one_stack()
    {
        _adventDay5.AddCrateToStack(1, "");
        var firstStack = GetFirstStack();
        Assert.Equal(1, firstStack.Count());
    }

    private IList<string> GetFirstStack()
    {
        return _adventDay5.GetCargo().GetStackById(1);
    }

    [Fact]
    public void _004_cargo_has_two_crates_in_one_stack()
    {
        _adventDay5.AddCrateToStack(1, "");
        _adventDay5.AddCrateToStack(1, "");
        Assert.Equal(2, GetFirstStack().Count());
    }

    [Fact]
    public void _005_cargo_has_one_crate_named_H_in_one_stack()
    {
        _adventDay5.AddCrateToStack(1, "H");
        var firstCrate = GetFirstStack().First();
        Assert.Equal("H", firstCrate);
    }

    [Fact]
    public void _006_get_cargo_returns_cargo_type()
    {
        _adventDay5.AddCrateToStack(1, "H");
        Assert.IsType<Cargo>(_adventDay5.GetCargo());
    }

    [Fact]
    public void _007_cargo_can_get_stack_by_id_returns_not_null()
    {
        _adventDay5.AddCrateToStack(1, "H");
        Assert.NotNull(GetFirstStack());
    }

    [Fact]
    public void _008_cargo_has_one_emtpy_stack()
    {
        Assert.Empty(GetFirstStack());
    }

    [Fact]
    public void _009_cargo_has_one_crate_in_stack_1()
    {
        _adventDay5.AddCrateToStack(1, "");
        Assert.Single(GetFirstStack());
    }
    
    [Fact]
    public void _010_cargo_has_one_crate_named_H_in_stack_1()
    {
        _adventDay5.AddCrateToStack(1, "H");
        Assert.Equal("H",GetFirstStack()[0]);
    }
    
    [Fact(Skip = $"same as {nameof(_004_cargo_has_two_crates_in_one_stack)}")]
    public void _011_cargo_has_two_crates_in_one_stack()
    {
        _adventDay5.AddCrateToStack(1, "");
        _adventDay5.AddCrateToStack(1, "");
        Assert.Equal(2, GetFirstStack().Count());
    }
}