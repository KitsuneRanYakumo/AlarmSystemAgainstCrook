public static class Utils
{
    public static float GetTargetValue(bool needMax, float maxValue, float minValue)
    {
        if (needMax)
            return maxValue;
        else
            return minValue;
    }

    public static int GetSingOfNumber(bool isPositive)
    {
        if (isPositive)
            return 1;
        else
            return -1;
    }
}