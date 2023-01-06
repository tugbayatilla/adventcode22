namespace AdventOfCode22.Day6;

public class AdventDay6UnitTests
{
    [Fact]
    public void Marker_is_zero_when_buffer_is_empty()
    {
        Assert.Equal(0,ElfCommSystem.FindMarker(""));
    }
    
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
    
    
}