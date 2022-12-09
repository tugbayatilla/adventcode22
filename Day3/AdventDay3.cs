namespace AdventOfCode22.Day3;

public class AdventDay3
{
    private int _sumOfPriorityItems;

    public int SumOfPriorities()
    {
        return _sumOfPriorityItems;
    }

    public void IdentifyAndStorePriorityItem(string priorityItem)
    {
        var upperLetterList = string.Join("",Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c));
        var lowerLetterList = string.Join("",Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c));

        var fullTable = string.Concat(lowerLetterList, upperLetterList);
            
        _sumOfPriorityItems += fullTable.IndexOf(priorityItem) + 1;
    }
}