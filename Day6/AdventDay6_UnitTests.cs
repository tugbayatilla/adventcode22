namespace AdventOfCode22.Day6;

public class AdventDay6UnitTests
{
    [Theory]
    [InlineData("", 0)]
    [InlineData("asd", 0)]
    [InlineData("abcd", 4)]
    [InlineData("__cde", 5)]
    [InlineData("____", 0)]
    public void Marker_finds_when_buffer_given(string buffer, int marker)
    {
        Assert.Equal(marker,ElfCommSystem.FindMarker(buffer));
    }
    
    
}