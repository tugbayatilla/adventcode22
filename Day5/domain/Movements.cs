using System.Collections;

namespace AdventOfCode22.Day5.domain;

public class Movements : IEnumerable<Movement>
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

    public IEnumerator<Movement> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}