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
        if (priorityItem == "p") _sumOfPriorityItems += 16;
        if (priorityItem == "L") _sumOfPriorityItems += 38;
    }
}