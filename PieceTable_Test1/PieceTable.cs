using System.Collections.Generic;
using System.Text;

namespace PieceTable_Test1;

public class PieceTable
{
    private readonly LinkedList<Piece> _pieces = new();

    public PieceTable()
    {
        _pieces.AddLast(new Piece()
        {
            Start = 0,
            Length = 6,
            Text = "123456",
            Type = EnumType.Origin
        });
    }

    public void Insert(string text, int startPosition)
    {
        if (!_pieces.Any())
        {
            _pieces.AddLast(new Piece()
            {
                Start = 0,
                Length = text.Length,
                Text = text,
                Type = EnumType.Append
            });
        }

        var node = Find(position: startPosition);
        var diff = node.Value.Length - startPosition;
        node.Value.Length = startPosition;

        var appendNode = new LinkedListNode<Piece>(new Piece()
        {
            Start = 0,
            Length = text.Length,
            Text = text,
            Type = EnumType.Append
        });
        
        _pieces.AddAfter(node: node, appendNode);

        _pieces.AddAfter(node: appendNode, new LinkedListNode<Piece>(new Piece
        {
            Start = node.Value.Length,
            Length = diff,
            Text = node.Value.Text,
            Type = node.Value.Type
        }));
    }

    private LinkedListNode<Piece> Find(int position)
    {
        var node = _pieces.First;
        var count = node.Value.Length;

        while (node.Next != null && count < position)
        {
            count += node.Next.Value.Length;
            node = node.Next;
        }

        return node;
    }

    public string Show()
    {
        var result = new StringBuilder();
        foreach (var piece in _pieces)
        {
            result.Append(piece.Text.Substring(piece.Start, piece.Length));
        }

        return result.ToString();
    }
}