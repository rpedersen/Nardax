namespace Nardax
{
    public static class LongExtensions
    {
        public static long Map(this long i, long inMin, long inMax, long outMin, long outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static long Map(this long i, long inMin, long inMax, long outMin, long outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static long Constrain(this long i, long min, long max)
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