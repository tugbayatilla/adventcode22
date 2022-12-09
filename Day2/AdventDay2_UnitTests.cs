namespace AdventOfCode22.Day2;

public class AdventDay2UnitTests
{
    private const string OppRock = "A";
    private const string MePaper = "Y";
    private const string OppPaper = "B";
    private const string MeRock = "X";
    private const string OppScissors = "C";
    private const string MeScissors = "Z";
    private const int PaperWinPoint = AdventDay2.PaperPoint + AdventDay2.WinPoint;
    private const int ScissorsWinPoint = AdventDay2.ScissorsPoint + AdventDay2.WinPoint;
    private const int RockWinPoint = AdventDay2.RockPoint + AdventDay2.WinPoint;
    private const int PaperLosePoint = AdventDay2.PaperPoint;
    private const int RockLosePoint = AdventDay2.RockPoint;
    private const int ScissorsLosePoint = AdventDay2.ScissorsPoint;
    private const int ScissorsDrawPoint = AdventDay2.DrawPoint + AdventDay2.ScissorsPoint;
    private const int PaperDrawPoint = AdventDay2.DrawPoint + AdventDay2.PaperPoint;
    private const int RockDrawPoint = AdventDay2.DrawPoint + AdventDay2.RockPoint;
    

    [Fact]
    public void _001_Day2_exist()
    {
        AdventDay2 adventDay2 = new();

        Assert.NotNull(adventDay2);
    }

    [Fact(Skip = "unwanted requirement")]
    public void _002_opponents_and_i_say_nothing_then_i_get_zero_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(0, adventDay2.Calculate("", ""));
    }

    [Fact(Skip = "Logic changed, not valid anymore")]
    public void _003_opponents_says_Rock_and_i_say_Paper_then_i_win_and_get_8_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(8, adventDay2.Calculate(OppRock, MePaper));
    }

    [Fact]
    public void _004_opponents_says_Paper_and_i_say_Rock_then_i_lost_and_get_1_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(1, adventDay2.Calculate(OppPaper, MeRock));
    }

    [Fact(Skip = $"{nameof(_006_Situations)} is covering this test.")]
    public void _005_opponents_says_Scissors_and_i_say_scissors_then_we_draw_and_get_6_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(ScissorsDrawPoint, adventDay2.Calculate(OppScissors, MeScissors));
    }

    [Theory(Skip = "Part2 Logic changed, so this test is not valid anymore")]
    [InlineData(OppScissors, MeScissors, ScissorsDrawPoint)]
    [InlineData(OppPaper, MePaper, PaperDrawPoint)]
    [InlineData(OppRock, MeRock, RockDrawPoint)]
    [InlineData(OppRock, MePaper, PaperWinPoint)]
    [InlineData(OppPaper, MeScissors, ScissorsWinPoint)]
    [InlineData(OppScissors, MeRock, RockWinPoint)]
    [InlineData(OppRock, MeScissors, ScissorsLosePoint)]
    [InlineData(OppPaper, MeRock, RockLosePoint)]
    [InlineData(OppScissors, MePaper, PaperLosePoint)]
    public void _006_Situations(string opp, string me, int expectedPoint)
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(expectedPoint, adventDay2.Calculate(opp, me));
    }
    
    [Fact]
    public void _007_read_data_from_file()
    {
        AdventDay2 adventDay2 = new();

        Assert.NotEmpty(adventDay2.ReadDataFile("Day2/AdventDay2.data"));
    }
    
    [Fact(Skip = "Logic changed, so not valid anymore")]
    public void _008_play()
    {
        AdventDay2 adventDay2 = new();
        var data = new string[]{ "A Y", "B X", "C Z" };

        Assert.Equal(15, adventDay2.play(data));
    }
    
    [Theory]
    [InlineData(OppScissors, "Y", AdventDay2.ScissorsPoint + AdventDay2.DrawPoint)]
    [InlineData(OppPaper, "Y", AdventDay2.PaperPoint + AdventDay2.DrawPoint)]
    [InlineData(OppRock, "Y", AdventDay2.RockPoint + AdventDay2.DrawPoint)]
    public void _009_Part2_Draw_Situations(string opp, string result, int expectedPoint)
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(expectedPoint, adventDay2.Calculate(opp, result));
    }
    
    [Fact]
    public void _010_part2_play()
    {
        AdventDay2 adventDay2 = new();
        var data = new string[]{ "A Y", "B X", "C Z" };

        Assert.Equal(12, adventDay2.play(data));
    }
    
    [Fact]
    public void _011_opponents_says_Rock_and_i_say_Paper_then_i_win_and_get_4_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(4, adventDay2.Calculate(OppRock, MePaper));
    }
}