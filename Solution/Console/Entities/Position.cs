namespace Console.Entities
{
    public struct Position
    {
        public readonly int yaxis;
        public readonly int xaxis;

        public Position(int x = default, int y = default)
        {
            if (x < 0)
                x = default;

            if (y < 0)
                y = default;

            yaxis = y;
            xaxis = x;
        }
    }
}
