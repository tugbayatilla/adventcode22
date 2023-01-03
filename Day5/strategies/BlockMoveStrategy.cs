using AdventOfCode22.Day5.domain;

namespace AdventOfCode22.Day5.strategies;

public class BlockMoveStrategy : IMoveStrategy
{
    private readonly Cargo cargo;

    public BlockMoveStrategy(Cargo cargo)
    {
        this.cargo = cargo;
    }

    public void Move(Movement movement)
    {
        var fromStack = cargo.GetStackById(movement.From);
        var toStack = cargo.GetStackById(movement.To);

        var movingCount = fromStack.Count < movement.Move ? fromStack.Count : movement.Move;

        var tempStack = new Stack<string>();
        for (var i = 0; i < movingCount; i++)
        {
            tempStack.Push(fromStack.RemoveCrate());
        }

        foreach (var stack in tempStack)
        {
            toStack.AddCrates(stack);
        }
    }
}