namespace Nardax
{
    public static class DoubleExtensions
    {
        public static double Map(this double i, double inMin, double inMax, double outMin, double outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static double Map(this double i, double inMin, double inMax, double outMin, double outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static double Constrain(this double i, double min, double max)
        {
            if (i < min)
            {
                return min;
            }

            if (i > max)
            {
                return max;
            }

            return i;
        }
    }
}