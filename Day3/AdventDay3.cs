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

    public void IdentifyAndStorePriorityItem(char priorityItem)
    {
        var fullTable = string.Concat(_lowerLetterList, _upperLetterList);
            
        _sumOfPriorityItems += fullTable.IndexOf(priorityItem) + 1;
    }

    public char FindErrorInItems(string items)
    {
        var halfIndex = items.Length / 2;
        var firstCompartment = items.Substring(0, halfIndex);
        var secondCompartment = items.Substring(halfIndex);

        var error = firstCompartment.Intersect(secondCompartment);
        return error.First();
    }

    public char FindBadge(string[] rucksacks)
    {
        var hashSet = new HashSet<char>(rucksacks[0]);
        hashSet.IntersectWith(rucksacks[1]);
        hashSet.IntersectWith(rucksacks[2]);
        var intersection = hashSet.ToList();
        
        return intersection.First();
    }
}