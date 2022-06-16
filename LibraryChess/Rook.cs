//Garaeva Ruslana, Chess 4, 220, 06.22

using System;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(int newX, int newY) : base(newX, newY)
        { }

        public Rook(string position) : base(position)
        { }

        public override bool TestMove(int newX, int newY)
        {
            return (x == newX || y == newY);
        }
    }
}
