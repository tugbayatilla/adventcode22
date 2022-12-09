namespace AdventOfCode22.Day3;

public class AdventDay3
{
    private int _sumOfPriorityItems;
    private readonly string _upperLetterList = string.Join("",Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c));
    private readonly string _lowerLetterList = string.Join("",Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c));

    public int SumOfPriorities()
    {
        return _sumOfPriorityItems;
    }

    public void IdentifyAndStorePriorityItem(string priorityItem)
    {
        var fullTable = string.Concat(_lowerLetterList, _upperLetterList);
            
        _sumOfPriorityItems += fullTable.IndexOf(priorityItem) + 1;
    }
}