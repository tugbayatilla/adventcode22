using System.Diagnostics;

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
    private const int ScissorsDrawPoint = 6;
    private const int PaperDrawPoint = 4;
    private const int RockDrawPoint = 2;

    [Fact]
    public void _001_Day2_exist()
    {
        AdventDay2 adventDay2 = new();

        Assert.NotNull(adventDay2);
    }

    [Fact]
    public void _002_opponents_and_i_say_nothing_then_i_get_zero_point()
    {
        AdventDay2 adventDay2 = new();

        Assert.Equal(0, adventDay2.Calculate("", ""));
    }

    [Fact]
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

    [Theory]
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

}

public class AdventDay2
{
    public const int WinPoint = 6;
    public const int PaperPoint = 2;
    public const int RockPoint = 1;
    public const int ScissorsPoint = 3;

    private const string Rock = "rock";
    private const string Paper = "paper";
    private const string Scissors = "scissors";

    public int Calculate(string opponentSelection, string mySelection)
    {
        var result = 0;

        opponentSelection = ConvertToCommonDefinitions(opponentSelection);
        mySelection = ConvertToCommonDefinitions(mySelection);

        if (opponentSelection == mySelection)
        {
            return CalculateDrawPoints(opponentSelection);
        }
        
        result = CalculateWinPoints(opponentSelection, mySelection, result);

        return result;
    }

    private int CalculateWinPoints(string opponentSelection, string mySelection, int result)
    {
        var won = (opponentSelection == Rock && mySelection == Paper)
                  || (opponentSelection == Paper && mySelection == Scissors)
                  || (opponentSelection == Scissors && mySelection == Rock);


        result += mySelection switch
        {
            Rock => RockPoint,
            Paper => PaperPoint,
            Scissors => ScissorsPoint,
            _ => 0
        };

        if (won) result += WinPoint;
        return result;
    }

    private int CalculateDrawPoints(string opponentSelection)
    {
        return opponentSelection switch
        {
            Rock => RockPoint * 2,
            Paper => PaperPoint * 2,
            Scissors => ScissorsPoint * 2,
            _ => 0
        };
    }

    private string ConvertToCommonDefinitions(string selection) =>
        selection switch
        {
            "A" or "X" => Rock,
            "B" or "Y" => Paper,
            "C" or "Z" => Scissors,
            _ => ""
        };
}