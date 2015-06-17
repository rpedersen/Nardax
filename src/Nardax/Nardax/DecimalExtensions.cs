namespace Nardax
{
    public static class DecimalExtensions
    {
        public static decimal Map(this decimal i, decimal inMin, decimal inMax, decimal outMin, decimal outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static decimal Map(this decimal i, decimal inMin, decimal inMax, decimal outMin, decimal outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static decimal Constrain(this decimal i, decimal min, decimal max)
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