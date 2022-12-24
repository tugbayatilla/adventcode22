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
        var stack = _adventDay5.GetCargo().AddStack();
        Assert.Equal(0, stack.Count);
    }

    [Fact]
    public void _003_cargo_has_one_crate_in_one_stack()
    {
        var cargo = _adventDay5.GetCargo();

        Assert.Equal(1, cargo.AddStack("A").Count);
    }

    private IList<string> GetFirstStack()
    {
        var cargo = _adventDay5.GetCargo();
        return cargo.GetStackById(1);
    }

    [Fact]
    public void _004_cargo_has_two_crates_in_one_stack()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.AddStack("A", "B");

        Assert.Equal(2, GetFirstStack().Count());
    }

    [Fact]
    public void _005_cargo_has_one_crate_named_H_in_one_stack()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.AddStack("H");

        var firstCrate = GetFirstStack().First();
        Assert.Equal("H", firstCrate);
    }

    [Fact]
    public void _006_get_cargo_returns_cargo_type()
    {
        Assert.IsType<Cargo>(_adventDay5.GetCargo());
    }

    [Fact(Skip = $"same as {nameof(_005_cargo_has_one_crate_named_H_in_one_stack)}")]
    public void _007_cargo_can_get_stack_by_id_returns_not_null()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.AddStack("H");
        Assert.NotNull(GetFirstStack());
    }

    [Fact()]
    public void _008_cargo_has_one_emtpy_stack()
    {
        _adventDay5.GetCargo().AddStack();
        Assert.Empty(GetFirstStack());
    }

    [Fact(Skip = $"same as {nameof(_008_cargo_has_one_emtpy_stack)}")]
    public void _009_cargo_has_one_crate_in_stack_1()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.AddStack("");
        Assert.Single(GetFirstStack());
    }

    [Fact]
    public void _010_cargo_has_one_crate_named_H_in_stack_1()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.AddStack("H");
        Assert.Equal("H", GetFirstStack()[0]);
    }

    [Fact(Skip = $"same as {nameof(_004_cargo_has_two_crates_in_one_stack)}")]
    public void _011_cargo_has_two_crates_in_one_stack()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.AddStack("");
        var cargo1 = _adventDay5.GetCargo();
        cargo1.AddStack("");
        Assert.Equal(2, GetFirstStack().Count());
    }

    [Fact]
    public void _012_cargo_has_two_stacks()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.AddStack();
        cargo.AddStack();
        Assert.Equal(2, cargo.StackCount());
    }

    [Fact]
    public void _013_cargo_has_two_crates_in_each_two_stacks()
    {
        var cargo = _adventDay5.GetCargo();

        var stack1 = cargo.AddStack("A", "B");
        var stack2 = cargo.AddStack("C", "D");

        Assert.Equal(2, stack1.Count);
        Assert.Equal(2, stack2.Count);
    }

    [Fact]
    public void _014_move_one_crate_from_first_stack_to_second_stack()
    {
        var cargo = _adventDay5.GetCargo();

        var stack1 = cargo.AddStack("A", "B");
        var stack2 = cargo.AddStack("C", "D");


        cargo.Move(1, 2, 1);

        Assert.Equal(1, stack1.Count);
        Assert.Equal(3, stack2.Count);
    }

    [Fact(Skip = $"because of {nameof(_016_move_from_stack_to_stack_and_get_the_result)}")]
    public void _015_move_B_from_stack_1_and_stack_2_will_be_in_order_of_C_D_B()
    {
        var cargo = _adventDay5.GetCargo();

        cargo.AddStack("A", "B");
        cargo.AddStack("C", "D");

        cargo.Move(1, 2, 1);

        Assert.True(cargo.GetStackById(2).SequenceEqual(new[] {"C", "D", "B"}));
    }

    [Theory]
    [InlineData(1, new[] {"A", "B"}, new[] {"C", "D"}, new[] {"C", "D", "B"})]
    [InlineData(2, new[] {"A", "B"}, new[] {"C", "D"}, new[] {"C", "D", "B", "A"})]
    [InlineData(3, new[] {"A", "B"}, new[] {"C", "D"}, new[] {"C", "D", "B", "A"})]
    [InlineData(3, new string[] { }, new[] {"C", "D"}, new[] {"C", "D"})]
    public void _016_move_from_stack_to_stack_and_get_the_result(
        int numberOfCratesToMove,
        string[] fromStack,
        string[] toStack,
        string[] expectedToStack)
    {
        var cargo = _adventDay5.GetCargo();

        cargo.AddStack(fromStack);
        cargo.AddStack(toStack);

        cargo.Move(1, 2, numberOfCratesToMove);

        Assert.True(cargo.GetStackById(2).SequenceEqual(expectedToStack));
    }

    [Fact]
    public void _017_file_data_returns_not_null_cargo_and_movements()
    {
        (Cargo cargo, Movements movements) = _adventDay5.ParseFile(Enumerable.Empty<string>());

        Assert.NotNull(cargo);
        Assert.NotNull(movements);
    }

    [Fact]
    public void _018_file_data_contains_one_stack_with_two_crates()
    {
        var stackWithTwoCrates = new[] {"[_]", "[__]", " 1 "};
        (Cargo cargo, _) = _adventDay5.ParseFile(stackWithTwoCrates);

        Assert.Equal(1, cargo.StackCount());
        var cratesCount = cargo.GetStackById(1).Count;
        Assert.Equal(2, cratesCount);
    }

    [Fact]
    public void _019_file_data_contains_one_stack_with_two_crates_names_B_and_B()
    {
        var stackWithTwoCrates = new[] {"[A]", "[B]", " 1 "};
        (Cargo cargo, _) = _adventDay5.ParseFile(stackWithTwoCrates);

        Assert.True(cargo.GetStackById(1).SequenceEqual(new[] {"B", "A"}));
    }
    
    [Fact]
    public void _020_file_data_contains_two_stacks_with_two_crates_each()
    {
        var stackWithTwoCrates = new[] {"[_] [_]", "[_] [_]", " 1   2 "};
        (Cargo cargo, _) = _adventDay5.ParseFile(stackWithTwoCrates);

        Assert.Equal(2, cargo.StackCount());
    }
}