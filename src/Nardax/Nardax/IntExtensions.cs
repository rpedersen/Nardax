namespace Nardax
{
    public static class IntExtensions
    {
        public static int Map(this int i, int inMin, int inMax, int outMin, int outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static int Map(this int i, int inMin, int inMax, int outMin, int outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static int Constrain(this int i, int min, int max)
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
