namespace AdventOfCode22.Day4;

public class AdventDay4
{
    private int _totalPairs;

    public int GetNumberOfPairsFullyCoverOther()
    {
        return _totalPairs;
    }

    public void AddPairDefinition(string pairDefinition)
    {
        _totalPairs = 1;
    }


    public IEnumerable<string> SplitPairDefinitionToTwo(string pairDefinition)
    {
        return pairDefinition.Split(",");
    }

    public IEnumerable<int> ConvertAssignmentToRange(string assignment)
    {
        var split = assignment.Split("-");
        var first = int.Parse(split[0]);
        var second = int.Parse(split[1]);
        
        return Enumerable.Range(first, second-first+1);
    }

    public bool IsOverlapFully(string pairDefinition)
    {
        var splitDefinition = SplitPairDefinitionToTwo(pairDefinition);
        var firstRange = ConvertAssignmentToRange(splitDefinition.First());
        var secondRange = ConvertAssignmentToRange(splitDefinition.Last());

        return Enumerable.SequenceEqual(firstRange.Intersect(secondRange), firstRange)
            || Enumerable.SequenceEqual(secondRange.Intersect(firstRange), secondRange);
    }
}