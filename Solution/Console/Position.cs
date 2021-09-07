namespace Console
{
    public struct Position
    {
        public readonly int yaxis;
        public readonly int xaxis;

        public Position(int x = 0, int y = 0)
        {
            yaxis = y;
            xaxis = x;
        }
    }
}
