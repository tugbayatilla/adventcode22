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

    [Fact]
    public void _004_split_pair_definition_to_two()
    {
        var pair = _adventDay4.SplitPairDefinitionToTwo("1-1,2-2");
        Assert.Equal("1-1", pair.First());
        Assert.Equal("2-2", pair.Last());
    }

    [Fact(Skip = $"new theory test is cover this test. {nameof(_006_convert_an_assignment_to_range)}")]
    public void _005_convert_an_assignment_to_range()
    {
        Assert.Equal(Enumerable.Range(1, 1), _adventDay4.ConvertAssignmentToRange("1-1"));
    }

    [Theory]
    [InlineData("1-1", new[] {1})]
    [InlineData("2-2", new[] {2})]
    [InlineData("1-2", new[] {1,2})]
    [InlineData("2-4", new[] {2,3,4})]
    [InlineData("6-8", new[] {6,7,8})]
    public void _006_convert_an_assignment_to_range(string givenAssignment, int[] expectedArray)
    {
        Assert.Equal(expectedArray.AsEnumerable(), _adventDay4.ConvertAssignmentToRange(givenAssignment));
    }
    
    [Fact(Skip = $"new theory test is cover this test. {nameof(_008_check_overlap_pairs_with_given_pair_definitions)}")]
    public void _007_overlap_pairs_returns_true()
    {
        Assert.True(_adventDay4.IsOverlap("1-1, 1-1"));
    }
    
    [Theory]
    [InlineData("1-1,1-1", true)]
    [InlineData("2-4,6-8", false)]
    [InlineData("2-3,4-5", false)]
    [InlineData("5-7,7-9", false)]
    [InlineData("2-8,3-7", true)]
    [InlineData("6-6,4-6", true)]
    [InlineData("2-6,4-8", false)]
    public void _008_check_overlap_pairs_with_given_pair_definitions(string pairDefinition, bool expected)
    {
        Assert.Equal(expected, _adventDay4.IsOverlap(pairDefinition));
    }
}