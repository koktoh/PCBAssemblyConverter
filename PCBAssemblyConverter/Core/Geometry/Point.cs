namespace PCBAssemblyConverter.Core.Geometry
{
    public readonly record struct Point(double X, double Y)
    {
        public static Point operator +(Point p, Vector2D v) => new(p.X + v.X, p.Y + v.Y);
    }
}
