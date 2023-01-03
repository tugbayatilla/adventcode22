using AdventOfCode22.Day5.domain;

namespace AdventOfCode22.Day5.strategies;

public class StackMoveStrategy : IMoveStrategy
{
    private readonly Cargo cargo;

    public StackMoveStrategy(Cargo cargo)
    {
        this.cargo = cargo;
    }

    public void Move(Movement movement)
    {
        var fromStack = cargo.GetStackById(movement.From);
        var toStack = cargo.GetStackById(movement.To);

        var movingCount = fromStack.Count < movement.Move ? fromStack.Count : movement.Move;

        for (var i = 0; i < movingCount; i++)
        {
            toStack.AddCrates(fromStack.RemoveCrate());
        }
    }
}
