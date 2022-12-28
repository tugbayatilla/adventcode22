namespace AdventOfCode22.Day5;

public class Movements
{
    private readonly List<Movement> _list = new ();

    public Movement GetByIndex(int index)
    {
        return _list[index];
    }

    public void Add(Movement givenMovement)
    {
        _list.Add(givenMovement);
    }
}