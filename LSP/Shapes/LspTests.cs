using FluentAssertions;
using Xunit;

namespace SOLID.LSP.Shapes
{
    public class LspTests
    {
        [Fact]
        public void Rectangle_Tests()
        {
            Rectangle rectangle = new Rectangle(2, 3);
            rectangle.Width.Should().Be(2);
            rectangle.Height.Should().Be(3);
            rectangle.Area.Should().Be(6);

            rectangle.Width = 4;    // 2 => 4
            rectangle.Width.Should().Be(4);
            rectangle.Height.Should().Be(3);
            rectangle.Area.Should().Be(12);
        }

        [Fact]
        public void Square_Tests()
        {
            Rectangle square = new Square(2);
            square.Area.Should().Be(4);

            square.Width.Should().Be(2);    // Width ??
            square.Height.Should().Be(2);   // Height ??
            //square.Side.Should().Be(2);   // compilation error!

            square.Width = 4;
            square.Width.Should().Be(4);
            square.Height.Should().Be(4);   // ???
            square.Area.Should().Be(16);    // ???
        }


        [Fact]
        public void BetterSquare_Tests()
        {
            BetterSquare square = new BetterSquare(2);
            square.Side.Should().Be(2);
            square.Area.Should().Be(4);

            square.Side = 3;
            square.Side.Should().Be(3);
            square.Area.Should().Be(9);
        }
    }

    public class BetterSquare // NOT derived from Rectangle!
    {
        public int Side { get; set; }
        public int Area => Side * Side;

        public BetterSquare(int side)
        {
            Side = side;
        }
    }
}
