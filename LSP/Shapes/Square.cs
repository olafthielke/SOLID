namespace SOLID.LSP
{
    public class Square : Rectangle
    {
        public int Side => Width;

        public Square(int side) 
            : base(side, side)
        { }
    }
}
