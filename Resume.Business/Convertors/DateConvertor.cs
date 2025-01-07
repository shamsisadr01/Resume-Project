using System.Globalization;

namespace Resume.Business.Convertors;

public static class DateConvertor
{
    public static string ToShamsi(this DateOnly value)
    {
        PersianCalendar pc = new PersianCalendar();

        DateTime date = new DateTime(value.Year,value.Month,value.Day,0,0,0);

        int year = pc.GetYear(date);
        int month = pc.GetMonth(date);
        int day = pc.GetDayOfMonth(date);

        return $"{year}/{month.ToString("00")}/{day.ToString("00")}";
    }
}