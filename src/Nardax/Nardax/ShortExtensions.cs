namespace Nardax
{
    public static class ShortExtensions
    {
        public static short Map(this short i, short inMin, short inMax, short outMin, short outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static short Map(this short i, short inMin, short inMax, short outMin, short outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (short)((i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
        }

        public static short Constrain(this short i, short min, short max)
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
