namespace CodeAdvent;

public class Clue
{
    private readonly string _pattern;

    private readonly int _inPositionElementCount;

    private readonly int _outOfPositionElementCount;

    public Clue(string pattern, int inPositionElementCount, int outOfPositionElementCount)
    {
        _pattern = pattern;
        _inPositionElementCount = inPositionElementCount;
        _outOfPositionElementCount = outOfPositionElementCount;
    }

    public bool Matches(string input)
        => input.Length != _pattern.Length
            ? throw new ArgumentOutOfRangeException(nameof(input), "The length of input and clue pattern must match.")
            : GetInPositionMatchCount(input) == _inPositionElementCount
              && GetOutOfPositionMatchCount(input) == _outOfPositionElementCount;

    private int GetInPositionMatchCount(string input)
        => _pattern.Select((c, idx) => c == input[idx] ? 1 : 0).Sum();

    private int GetOutOfPositionMatchCount(string input)
        => _pattern.Select((c, idx) => OccursOutOfPosition(input, c, idx) ? 1 : 0).Sum();

    private static bool OccursOutOfPosition(string input, char charToCheck, int position)
        => input[position] != charToCheck && input.Contains(charToCheck);
};
