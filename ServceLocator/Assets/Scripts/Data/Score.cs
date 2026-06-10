public class Score
{
    public int Value { get; private set; }
    public void AddPoint() => Value++;
    public void Reset() => Value = 0;
}
