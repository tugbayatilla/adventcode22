using AdventOfCode22.Day5.domain;

namespace AdventOfCode22.Day5.strategies;

public interface IMoveStrategy
{
    public void Move(Movement movement);
}