using System.Diagnostics;

namespace AdventOfCode22.Day2;

public class AdventDay2
{
    public const int WinPoint = 6;
    public const int DrawPoint = 3;
    public const int PaperPoint = 2;
    public const int RockPoint = 1;
    public const int ScissorsPoint = 3;

    private const string Rock = "rock";
    private const string Paper = "paper";
    private const string Scissors = "scissors";

    public int Calculate(string firstColumn, string secondColumn)
    {
        var opponentSelection = ConvertToCommonDefinitions(firstColumn);

        var finalDecision = FinalDecision(secondColumn);

        if (finalDecision == "draw")
        {
            return CalculateDrawPoints(opponentSelection);
        }

        var meSelection = MeSelectionDecision(opponentSelection, finalDecision);

        var final = meSelection switch
        {
            Rock => RockPoint,
            Paper => PaperPoint,
            Scissors => ScissorsPoint,
            _ => 0
        };
        if (finalDecision == "lose")
        {
            return final;
        }
        if (finalDecision == "win")
        {
            final += CalculateWinPoints(finalDecision, meSelection);
        }

        return final;
    }

    private string FinalDecision(string secondColumn)
    {
        var finalDecision = secondColumn switch
        {
            "X" => "lose",
            "Y" => "draw",
            "Z" => "win"
        };
        return finalDecision;
    }

    private string MeSelectionDecision(string opponentSelection, string finalDecision) =>
        finalDecision switch
        {
            "lose" => opponentSelection switch
            {
                Paper => Rock,
                Rock => Scissors,
                Scissors => Paper,
            },
            "win" => opponentSelection switch
            {
                Paper => Scissors,
                Rock => Paper,
                Scissors => Rock,
            },
        };

    private int CalculateWinPoints(string finalDecision, string meSelection)
    {
        return WinPoint;
    }

    private int CalculateDrawPoints(string opponentSelection)
    {
        return opponentSelection switch
        {
            Rock => RockPoint + DrawPoint,
            Paper => PaperPoint + DrawPoint,
            Scissors => ScissorsPoint + DrawPoint,
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

    public IEnumerable<string> ReadDataFile(string fileName)
    {
        var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        var path = System.IO.Path.Combine(directory, fileName);

        return File.ReadAllText(path).Split(Environment.NewLine);
    }

    public int play(IEnumerable<string> data)
    {
        var result = 0;
        foreach (var d in data)
        {
            var selections = d.Split(" ");
            result += Calculate(selections[0], selections[1]);
        }

        return result;
    }
}