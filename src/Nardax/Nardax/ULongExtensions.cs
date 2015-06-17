namespace Nardax
{
    public static class ULongExtensions
    {
        public static ulong Map(this ulong i, ulong inMin, ulong inMax, ulong outMin, ulong outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static ulong Map(this ulong i, ulong inMin, ulong inMax, ulong outMin, ulong outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static ulong Constrain(this ulong i, ulong min, ulong max)
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