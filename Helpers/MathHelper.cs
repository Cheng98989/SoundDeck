using System;

namespace Echo
{
    public static class MathHelper
    {

        public static double LinearMapClamp(double value, double sourceMin, double sourceMax, double targetMin, double targetMax)
        {
            if (sourceMin == sourceMax)
                throw new ArgumentException("L'intervallo sorgente non può avere lunghezza zero.", nameof(sourceMin));

            // Calcolo lineare
            double mapped = targetMin + (value - sourceMin) * (targetMax - targetMin) / (sourceMax - sourceMin);

            // Clamp nell'intervallo target
            if (targetMin < targetMax)
                return Clamp(mapped, targetMin, targetMax);
            else
                return Clamp(mapped, targetMax, targetMin);
        }

        
        public static double Clamp(double value, double min, double max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}
