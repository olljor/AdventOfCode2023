
namespace Day4;
public class Card
{
    public int id { get; set; }
    public IEnumerable<int> refrenceNumbers { get; set; } = Enumerable.Empty<int>();
    public IEnumerable<int> winningNumbers { get; set; } = Enumerable.Empty<int>();
    public int copies { get; set; } = 1;
    public int score { get { return Part1Score(); } }
    public int TotalWins { get; set; } = 0;
    private int Part1Score()
    {
        int score = 0;
        for (int i = 0; i < TotalWins / copies; i++)
        {
            score = score * 2;
            if (score == 0)
                score++;
        }
        return score;
    }

}