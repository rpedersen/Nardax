namespace Nardax
{
    public static class UShortExtensions
    {
        public static ushort Map(this ushort i, ushort inMin, ushort inMax, ushort outMin, ushort outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static ushort Map(this ushort i, ushort inMin, ushort inMax, ushort outMin, ushort outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (ushort)((i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin);
        }

        public static ushort Constrain(this ushort i, ushort min, ushort max)
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