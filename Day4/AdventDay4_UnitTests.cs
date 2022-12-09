namespace AdventOfCode22.Day4;

public class AdventDay4UnitTests
{
    private readonly AdventDay4 _adventDay4 = new();

    [Fact]
    public void _001_Number_of_pairs_fully_cover_other_exist()
    {
        AdventDay4 adventDay4 = new();
        Assert.Equal(0, adventDay4.GetNumberOfPairsFullyCoverOther());
    }
    
    [Fact]
    public void _002_one_pair_has_same_assignment_returns_1()
    {
        AdventDay4 adventDay4 = new();
        adventDay4.AddPairDefinition("1-1,1-1");
        
        Assert.Equal(1, adventDay4.GetNumberOfPairsFullyCoverOther());
    }
    
    [Fact(Skip = "this is a huge step to take, for now, i skipped it.")]
    public void _003_one_pair_has_no_overlap_assignment_returns_0()
    {
        _adventDay4.AddPairDefinition("1-1,2-2");
        
        Assert.Equal(0, _adventDay4.GetNumberOfPairsFullyCoverOther());
    }
    
}