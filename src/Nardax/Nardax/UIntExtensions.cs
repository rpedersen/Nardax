namespace Nardax
{
    public static class UIntExtensions
    {
        public static uint Map(this uint i, uint inMin, uint inMax, uint outMin, uint outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static uint Map(this uint i, uint inMin, uint inMax, uint outMin, uint outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static uint Constrain(this uint i, uint min, uint max)
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