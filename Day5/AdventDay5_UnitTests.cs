using AdventOfCode22.Day5.domain;
using AdventOfCode22.Day5.strategies;

namespace AdventOfCode22.Day5;

public class AdventDay5UnitTests
{
    public const string MainDataFolderPath = "Day5/input/AdventDay5.data";
    private const string Test01DataPath = "Day5/input/test01.data";
    private const string Test02DataPath = "Day5/input/test02.data";
    private const string Test03DataPath = "Day5/input/test03.data";
    private readonly AdventDay5 _adventDay5 = new();

    [Fact]
    public void _002_cargo_has_one_emtpy_stack()
    {
        Assert.Equal(0, _adventDay5.GetCargo().CreateStackById(1).Count);
    }

    [Fact]
    public void _003_cargo_has_one_crate_in_one_stack()
    {
        Assert.Equal(1, _adventDay5.GetCargo().CreateStackById(1).AddCrates("A").Count);
    }

    [Fact]
    public void _004_cargo_has_two_crates_in_one_stack()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.CreateStackById(1).AddCrates("A", "B");

        Assert.Equal(2, cargo.GetStackById(1).Count);
    }

    [Fact]
    public void _005_cargo_has_one_crate_named_H_in_one_stack()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.CreateStackById(1).AddCrates("H");

        var firstCrate = cargo.GetStackById(1).GetCrateByIndex(0);
        Assert.Equal("H", firstCrate);
    }

    [Fact]
    public void _006_get_cargo_returns_cargo_type()
    {
        Assert.IsType<Cargo>(_adventDay5.GetCargo());
    }

    [Fact]
    public void _012_cargo_has_two_stacks()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.CreateStackById(1);
        cargo.CreateStackById(2);
        Assert.Equal(2, cargo.StackCount());
    }

    [Fact]
    public void _013_cargo_has_two_crates_in_each_two_stacks()
    {
        var cargo = _adventDay5.GetCargo();

        var stack1 = cargo.CreateStackById(1).AddCrates("A", "B");
        var stack2 = cargo.CreateStackById(2).AddCrates("C", "D");

        Assert.Equal(2, stack1.Count);
        Assert.Equal(2, stack2.Count);
    }

    [Theory]
    [InlineData(1, new[] {"A", "B"}, new[] {"C", "D"}, new[] {"C", "D", "B"})]
    [InlineData(2, new[] {"A", "B"}, new[] {"C", "D"}, new[] {"C", "D", "B", "A"})]
    [InlineData(3, new[] {"A", "B"}, new[] {"C", "D"}, new[] {"C", "D", "B", "A"})]
    [InlineData(3, new string[] { }, new[] {"C", "D"}, new[] {"C", "D"})]
    public void _016_move_from_stack_to_stack_and_get_the_result(
        int moves,
        string[] fromStack,
        string[] toStack,
        string[] expectedToStack)
    {
        var cargo = _adventDay5.GetCargo();

        var stack1 = cargo.CreateStackById(1).AddCrates(fromStack);
        var stack2 = cargo.CreateStackById(2).AddCrates(toStack);

        cargo.Move(new Movement(stack1.Id, stack2.Id, moves));

        Assert.True(stack2.IsEqual(expectedToStack));
    }

    [Fact]
    public void _017_file_data_returns_not_null_cargo_and_movements()
    {
        (Cargo cargo, Movements movements) = _adventDay5.ParseLines(Enumerable.Empty<string>());

        Assert.NotNull(cargo);
        Assert.NotNull(movements);
    }

    [Fact]
    public void _018_file_data_contains_one_stack_with_two_crates()
    {
        var stackWithTwoCrates = new[] {"[_]", "[__]", " 1 "};
        (Cargo cargo, _) = _adventDay5.ParseLines(stackWithTwoCrates);

        Assert.Equal(1, cargo.StackCount());
        var cratesCount = cargo.GetStackById(1).Count;
        Assert.Equal(2, cratesCount);
    }

    [Fact]
    public void _019_file_data_contains_one_stack_with_two_crates_names_B_and_B()
    {
        var stackWithTwoCrates = new[] {"[A]", "[B]", " 1 "};
        (Cargo cargo, _) = _adventDay5.ParseLines(stackWithTwoCrates);

        Assert.True(cargo.GetStackById(1).IsEqual(new[] {"B", "A"}));
    }

    [Fact]
    public void _020_file_data_contains_two_stacks_with_two_crates_each()
    {
        var stackWithTwoCrates = new[] {"[_] [_]", "[_] [_]", " 1   2 "};
        (Cargo cargo, _) = _adventDay5.ParseLines(stackWithTwoCrates);

        Assert.Equal(2, cargo.StackCount());
    }

    [Theory]
    [InlineData(Test01DataPath, 1, new[] {"Z", "N"})]
    [InlineData(Test01DataPath, 2, new[] {"M", "C", "D"})]
    [InlineData(Test01DataPath, 3, new[] {"P"})]
    public void _021_in_test01_data_given_stack_contains_given_crates(string filePath, int stackId, string[] crates)
    {
        var lines = AdventUtils.ReadDataFromAFile(filePath);
        (Cargo cargo, _) = _adventDay5.ParseLines(lines);

        Assert.True(cargo.GetStackById(stackId).IsEqual(crates));
    }

    [Theory]
    [InlineData(1, 2, 1)]
    public void _022_add_one_movement_and_get_same_movement_from_movements(int from, int to,
        int movementCount)
    {
        Movements movements = new Movements();
        Movement givenMovement = new(from, to, movementCount);
        movements.Add(givenMovement);

        Assert.Equal(givenMovement, movements.GetByIndex(0));
    }

    [Theory]
    [InlineData(Test02DataPath, 0, 1, 2, 1)]
    [InlineData(Test02DataPath, 1, 3, 1, 3)]
    [InlineData(Test02DataPath, 2, 2, 2, 1)]
    [InlineData(Test02DataPath, 3, 1, 1, 2)]
    public void _023_in_test02_data_given_movements(string filePath, int movementIndex,
        int movementCount, int from, int to)
    {
        var lines = AdventUtils.ReadDataFromAFile(filePath);
        (_, Movements movements) = _adventDay5.ParseLines(lines);

        Assert.Equal(new Movement(from, to, movementCount), movements.GetByIndex(movementIndex));
    }

    [Theory]
    [InlineData(Test02DataPath, 0, 1, 2)]
    [InlineData(Test02DataPath, 0, 2, 3)]
    [InlineData(Test02DataPath, 0, 3, 1)]
    [InlineData(Test02DataPath, 1, 1, 3)]
    public void _024_in_test02_data_given_movements_applied_to_cargo_and_get_final(
        string filePath, int movementCount, int stackId, int numberOfCrates)
    {
        var lines = AdventUtils.ReadDataFromAFile(filePath);
        (Cargo cargo, Movements movements) = _adventDay5.ParseLines(lines);

        for (var i = 0; i < movementCount; i++)
        {
            cargo.Move(movements.GetByIndex(i));
        }

        Assert.Equal(numberOfCrates, cargo.GetStackById(stackId).Count);
    }

    [Theory]
    [InlineData(Test02DataPath, 3)]
    public void _026_Fix_cargo_stack_count_should_be_given(string filePath, int stackCount)
    {
        var lines = AdventUtils.ReadDataFromAFile(filePath);
        (Cargo cargo, _) = _adventDay5.ParseLines(lines);

        Assert.Equal(stackCount, cargo.StackCount());
    }

    [Theory]
    [InlineData(Test02DataPath, 0, 1, new[] {"Z", "N"})]
    [InlineData(Test02DataPath, 0, 2, new[] {"M", "C", "D"})]
    [InlineData(Test02DataPath, 0, 3, new[] {"P"})]
    [InlineData(Test02DataPath, 1, 1, new[] {"Z", "N", "D"})]
    [InlineData(Test02DataPath, 1, 2, new[] {"M", "C"})]
    [InlineData(Test02DataPath, 1, 3, new[] {"P"})]
    [InlineData(Test02DataPath, 2, 1, new string[] { })]
    [InlineData(Test02DataPath, 2, 2, new[] {"M", "C"})]
    [InlineData(Test02DataPath, 2, 3, new[] {"P", "D", "N", "Z"})]
    [InlineData(Test02DataPath, 3, 1, new[] {"C", "M"})]
    [InlineData(Test02DataPath, 3, 2, new string[] { })]
    [InlineData(Test02DataPath, 3, 3, new[] {"P", "D", "N", "Z"})]
    [InlineData(Test02DataPath, 4, 1, new[] {"C"})]
    [InlineData(Test02DataPath, 4, 2, new[] {"M"})]
    [InlineData(Test02DataPath, 4, 3, new[] {"P", "D", "N", "Z"})]
    public void _029_in_test02_data_given_movements_applied_to_cargo_and_get_final_crates(
        string filePath,
        int movementCount,
        int stackId,
        string[] lastStateOfCrates)
    {
        var lines = AdventUtils.ReadDataFromAFile(filePath);
        (Cargo cargo, Movements movements) = _adventDay5.ParseLines(lines);

        for (var i = 0; i < movementCount; i++)
        {
            cargo.Move(movements.GetByIndex(i));
        }

        Assert.True(cargo.GetStackById(stackId).IsEqual(lastStateOfCrates));
    }

    [Theory]
    [InlineData(MainDataFolderPath)]
    public void _030_after_rearrangement_crate_numbers_should_be_same(string filePath)
    {
        var lines = AdventUtils.ReadDataFromAFile(filePath);
        var tempAdventDay5 = new AdventDay5();
        (Cargo cargo, _) = tempAdventDay5.ParseLines(lines);

        var before = cargo.CrateCount();
        _adventDay5.AfterRearrangementCratesFromTopOfEachStacks(filePath);
        var after = _adventDay5.GetCargo().CrateCount();

        Assert.Equal(before, after);
    }

    [Fact]
    public void _031_cargo_is_using_stack_moving_strategy_as_default()
    {
        var cargo = _adventDay5.GetCargo();
        Assert.IsType<StackMoveStrategy>(cargo.MoveStrategy);
    }

    [Fact]
    public void _032_stack_movement_moves_the_crates()
    {
        var cargo = _adventDay5.GetCargo();
        var stack1 = cargo.CreateStackById(1).AddCrates("A", "B");
        var stack2 = cargo.CreateStackById(2).AddCrates("C", "D");

        cargo.MoveStrategy.Move(new Movement(stack1.Id, stack2.Id, 1));

        Assert.True(stack2.IsEqual(new[] {"C", "D", "B"}));
    }

    [Fact]
    public void _033_block_movement_moves_the_crates()
    {
        var cargo = _adventDay5.GetCargo();
        var stack1 = cargo.CreateStackById(1).AddCrates("A", "B");
        var stack2 = cargo.CreateStackById(2).AddCrates("C", "D");

        cargo.ChangeStrategy<BlockMoveStrategy>();

        cargo.Move(new Movement(stack1.Id, stack2.Id, 2));

        Assert.True(stack2.IsEqual(new[] {"C", "D", "A", "B"}));
    }

    [Fact]
    public void _034_get_cargo_and_parse_file_must_be_same_instance()
    {
        (Cargo cargo, _) = _adventDay5.ParseLines(Enumerable.Empty<string>());

        Assert.Same(cargo, _adventDay5.GetCargo());
    }

    [Theory]
    [InlineData(MainDataFolderPath, "FWNSHLDNZ", typeof(StackMoveStrategy))]
    [InlineData(MainDataFolderPath, "RNRGDNFQG", typeof(BlockMoveStrategy))]
    [InlineData(Test03DataPath, "ZGQCWCFG", typeof(StackMoveStrategy))]
    [InlineData(Test02DataPath, "CMZ", typeof(StackMoveStrategy))]
    public void _035_part2_actual_data_result(string filePath, string result, Type strategyType)
    {
        var cargo = _adventDay5.GetCargo();
        cargo.ChangeStrategy(strategyType);
        Assert.Equal(result, _adventDay5.AfterRearrangementCratesFromTopOfEachStacks(filePath));
    }
    
    [Fact]
    public void _036_change_strategy_of_cargo_with_generic_method()
    {
        var cargo = _adventDay5.GetCargo();
        cargo.ChangeStrategy<BlockMoveStrategy>();

        Assert.IsType<BlockMoveStrategy>(cargo.MoveStrategy);
    }
}