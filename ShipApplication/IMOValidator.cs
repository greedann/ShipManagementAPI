public static class IMOValidator
{
    public static bool IsValid(string imo)
    {
        if (imo == null || imo.Length != 7 || !imo.All(char.IsDigit))
            return false;

        int sum = 0;
        for (int i = 0; i < 6; i++)
        {
            sum += (7 - i) * (imo[i] - '0');
        }

        int checkDigit = sum % 10;
        return checkDigit == (imo[6] - '0');
    }
}
