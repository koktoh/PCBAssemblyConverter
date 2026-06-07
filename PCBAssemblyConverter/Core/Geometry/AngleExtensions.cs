namespace PCBAssemblyConverter.Core.Geometry
{
    public static class AngleExtensions
    {
        public static double ToRadians(this double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public static double ToDegrees(this double radians)
        {
            return radians * 180.0 / Math.PI;
        }

        public static double MirrorYDegrees(this double degrees)
        {
            var result = 180.0 - degrees;

            result = result.NormalizeUnsignedDegrees();

            return result;
        }

        public static double MirrorYRadians(this double radians)
        {
            var result = Math.PI - radians;

            result = result.NormalizeUnsignedRadians();

            return result;
        }

        public static double NormalizeSignedDegrees(this double degrees)
        {
            var result = degrees % 360.0;

            if (result > 180.0)
            {
                result -= 360.0;
            }

            if (result <= -180.0)
            {
                result += 360.0;
            }

            return result;
        }

        public static double NormalizeSignedRadians(this double radians)
        {
            var result = radians % (2 * Math.PI);

            if (result > Math.PI)
            {
                result -= 2 * Math.PI;
            }

            if (result <= -Math.PI)
            {
                result += 2 * Math.PI;
            }

            return result;
        }

        public static double NormalizeUnsignedDegrees(this double degrees)
        {
            var result = degrees % 360.0;

            if (result < 0)
            {
                result += 360.0;
            }

            return result;
        }

        public static double NormalizeUnsignedRadians(this double radians)
        {
            var result = radians % (2 * Math.PI);

            if (result < 0)
            {
                result += 2 * Math.PI;
            }

            return result;
        }
    }
}
