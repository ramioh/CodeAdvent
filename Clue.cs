namespace CodeAdvent;

public class Clue
{
    private readonly string _pattern;

    private readonly int _correctElementCount;

    private readonly bool _isInPosition;

    public Clue(string pattern, int correctElementCount, bool isInPosition)
    {
        _pattern = pattern;
        _correctElementCount = correctElementCount;
        _isInPosition = isInPosition;
    }

    public bool Matches(string input)
        => this switch
        {
            _ when input.Length != _pattern.Length
                => throw new ArgumentOutOfRangeException(nameof(input), "The length of input and clue pattern must match."),

            { _correctElementCount: 0 } => !input.Intersect(_pattern).Any(),
            { _isInPosition: false } => GetOutOfPositionOccurrenceCount(input) == _correctElementCount,
            { _isInPosition: true } => GetInPositionOccurrenceCount(input) == _correctElementCount,
        };

    private int GetInPositionOccurrenceCount(string input)
        => _pattern.Select((c, idx) => c == input[idx] ? 1 : 0).Sum();

    private int GetOutOfPositionOccurrenceCount(string input)
        => _pattern.Select((c, idx) => OccursOutOfPosition(input, c, idx) ? 1 : 0).Sum();

    private bool OccursOutOfPosition(string input, char charToCheck, int position)
        => input[position] != charToCheck && input.Contains(charToCheck);
};
