namespace Nardax
{
    public static class FloatExtensions
    {
        public static float Map(this float i, float inMin, float inMax, float outMin, float outMax)
        {
            return i.Map(inMin, inMax, outMin, outMax, false);
        }

        public static float Map(this float i, float inMin, float inMax, float outMin, float outMax, bool constrainInput)
        {
            if (constrainInput)
            {
                i = i.Constrain(inMin, inMax);
            }

            return (i - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        }

        public static float Constrain(this float i, float min, float max)
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