namespace AdventOfCode22.Day6;

public class AdventDay6UnitTests
{
    [Fact]
    public void Marker_is_zero_when_buffer_is_empty()
    {
        Assert.Equal(0,ElfCommSystem.FindMarker(""));
    }
}