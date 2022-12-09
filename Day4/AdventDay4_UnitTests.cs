namespace AdventOfCode22.Day4;

public class AdventDay4UnitTests
{
    [Fact]
    public void _001_Number_of_pairs_fully_cover_other_exist()
    {
        AdventDay4 adventDay4 = new();
        Assert.Equal(0, adventDay4.GetNumberOfPairsFullyCoverOther());
    }
}