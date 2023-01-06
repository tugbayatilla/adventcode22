namespace AdventOfCode22.Day6;

public class AdventDay6UnitTests
{
    [Fact]
    public void Marker_is_zero_when_buffer_contains_less_than_four_chars()
    {
        Assert.Equal(0,ElfCommSystem.FindMarker("asd"));
    }
    
    [Fact]
    public void Marker_is_four_when_buffer_only_contains_four_different_chars()
    {
        Assert.Equal(4,ElfCommSystem.FindMarker("abcd"));
    }
    
    [Theory]
    [InlineData("", 0)]
    public void Marker_finds_when_buffer_given(string buffer, int marker)
    {
        Assert.Equal(marker,ElfCommSystem.FindMarker(buffer));
    }
    
    
}