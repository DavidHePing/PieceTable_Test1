using FluentAssertions;
using PieceTable_Test1;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddText_Test_AddText_Result()
    {
        var pieceTable = new PieceTable();
        pieceTable.Insert("abc", 4);

        pieceTable.Show().Should().Be("1234abc56");
    }
}