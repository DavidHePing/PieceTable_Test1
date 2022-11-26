namespace PieceTable_Test1;

public class Piece
{
    public int Start { get; set; }
    public int Length { get; set; }
    public string Text { get; set; }
    public EnumType Type { get; set; }

    public override string ToString()
    {
        return $"{nameof(Start)}: {Start}, {nameof(Length)}: {Length}, {nameof(Text)}: {Text}, {nameof(Type)}: {Type}";
    }
}