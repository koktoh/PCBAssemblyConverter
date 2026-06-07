namespace PCBAssemblyConverter.Core.Geometry
{
    public static class Transform2D
    {
        public static Vector2D Rotate(double vectorX, double vectorY, double radians)
        {
            var cosTheta = Math.Cos(radians);
            var sinTheta = Math.Sin(radians);

            var xNew = vectorX * cosTheta - vectorY * sinTheta;
            var yNew = vectorX * sinTheta + vectorY * cosTheta;

            return new Vector2D(xNew, yNew);
        }

        public static Vector2D Rotate(Vector2D vector, double radians)
        {
            return Rotate(vector.X, vector.Y, radians);
        }

        public static Point Translate(double originX, double originY, double vectorX, double vectorY, double radians)
        {
            var rotatedVector = Rotate(vectorX, vectorY, radians);
            return new Point(originX + rotatedVector.X, originY + rotatedVector.Y);
        }

        public static Point Translate(Point origin, Vector2D vector, double radians)
        {
            return Translate(origin.X, origin.Y, vector.X, vector.Y, radians);
        }
    }
}
