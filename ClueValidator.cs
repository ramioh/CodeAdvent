namespace CodeAdvent;

public class ClueValidator
{
    private readonly Clue _clue;
    private readonly string _input;

    public ClueValidator(Clue clue, string input)
    {
        if (input.Length != clue.Pattern.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(input), "The length of input and clue pattern must match.");
        }

        _clue = clue;
        _input = input;
    }

    public bool SatisfiesClue()
        => _clue switch
        {
            { CorrectElementCount: 0 } => !_input.Intersect(_clue.Pattern).Any(),
            { IsPositionCorrect: false } => GetOutOfPositionOccurrenceCount() == _clue.CorrectElementCount,
            { IsPositionCorrect: true } => GetInPositionOccurrenceCount() == _clue.CorrectElementCount,
        };

    private int GetInPositionOccurrenceCount()
        => _clue.Pattern.Select((c, idx) => c == _input[idx] ? 1 : 0).Sum();

    private int GetOutOfPositionOccurrenceCount()
        => _clue.Pattern.Select((c, idx) => OccursOutOfPosition(c, idx) ? 1 : 0).Sum();

    private bool OccursOutOfPosition(char charToCheck, int position)
        => _input[position] != charToCheck && _input.Contains(charToCheck);
}
