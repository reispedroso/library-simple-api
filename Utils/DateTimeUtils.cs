public static class DateTimeUtils {
    public static DateTime ReplaceMinValueWithFutureDate(this DateTime date)
    {
        if (date == DateTime.MinValue)
        {
            return DateTime.Now.AddYears(1).ToAdjustedTime();
        }
        else
        {
            return date.ToAdjustedTime();
        }
    }

    public enum Timezones
    {
        Br
        
    }

    public static DateTime ToAdjustedTime(this DateTime dateTime, Timezones? currentTimezone = Timezones.Br)
    {
        return currentTimezone switch
        {
            Timezones.Br => dateTime.AddHours(+3),
            _ => dateTime
        };
    }

    
}