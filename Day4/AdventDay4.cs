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
}