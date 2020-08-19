public static class DateTimeUtility
{
    public static string NowDateString()
    {
        return System.DateTime.Now.ToString("yyyy-MM-dd");
    }

    public static string NowDateTimeString()
    {
        return System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
    }
}
