using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;

public class Cultures
{
    static Dictionary<DateTime, string> holidays = new Dictionary<DateTime, string>();

    public static void InitializePersianCulture()
    {
        InitializeCulture("fa-ir", new[] {"ی", "د", "س", "چ", "پ", "ج", "ش"},
            new[] {"یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"},
            new[]
            {
                "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                "بهمن", "اسفند", ""
            },
            new[]
            {
                "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
                "بهمن", "اسفند", ""
            }, "ق.ظ. ", "ب.ظ. ", "yyyy/MM/dd", new PersianCalendar());

        SetHoliday();


    }

    public static bool IsFriday(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Friday;
    }

    public static bool IsHoliday(DateTime date)
    {
        return holidays.ContainsKey(date);
    }

    private static void SetHoliday()
    {
        holidays.Add(DateTime.Parse("1398/01/01"),"عید نورزو");
        holidays.Add(DateTime.Parse("1398/01/02"),"عید نورزو");
        holidays.Add(DateTime.Parse("1398/01/03"),"عید نورزو");
        holidays.Add(DateTime.Parse("1398/01/04"),"عید نورزو");
        holidays.Add(DateTime.Parse("1398/01/12"),"عید نورزو");
        holidays.Add(DateTime.Parse("1398/01/13"),"عید نورزو");
        holidays.Add(DateTime.Parse("1398/01/14"),"عید مبعث");
        holidays.Add(DateTime.Parse("1398/02/01"),"تعطیل");
        holidays.Add(DateTime.Parse("1398/02/06"),"شهادت");
        holidays.Add(DateTime.Parse("1398/02/14"),"عید نورزو");
        holidays.Add(DateTime.Parse("1398/03/06"),"شهادت");
        holidays.Add(DateTime.Parse("1398/03/14"),"تعطیل");
        holidays.Add(DateTime.Parse("1398/03/15"),"تعطیل");
        holidays.Add(DateTime.Parse("1398/03/16"),"عید فطر");
        holidays.Add(DateTime.Parse("1398/04/08"),"شهادت");
        holidays.Add(DateTime.Parse("1398/05/21"),"عید قربان");
        holidays.Add(DateTime.Parse("1398/05/29"),"عید غدیر");
        holidays.Add(DateTime.Parse("1398/06/18"),"تاسوعا");
        holidays.Add(DateTime.Parse("1398/06/19"),"عاشورا");
        holidays.Add(DateTime.Parse("1398/07/27"),"اربعین");
        holidays.Add(DateTime.Parse("1398/08/05"),"رحلت");
        holidays.Add(DateTime.Parse("1398/08/07"),"شهادت");
        holidays.Add(DateTime.Parse("1398/08/15"),"شهادت");
        holidays.Add(DateTime.Parse("1398/11/09"), "شهادت");
        holidays.Add(DateTime.Parse("1398/11/22"), "تعطیل");
        holidays.Add(DateTime.Parse("1398/12/18"), "تعطیل");
        holidays.Add(DateTime.Parse("1398/11/29"), "تعطیل");
    }

    private static int DayInYear(DateTime date)
    {
        return date.DayOfYear;
    }
    public static void InitializeCulture(string culture, string[] abbreviatedDayNames, string[] dayNames,
        string[] abbreviatedMonthNames, string[] monthNames, string amDesignator,
        string pmDesignator, string shortDatePattern, Calendar calendar)
    {
        var calture = new CultureInfo(culture);
        var info = calture.DateTimeFormat;
        info.AbbreviatedDayNames = abbreviatedDayNames;
        info.DayNames = dayNames;
        info.AbbreviatedMonthNames = abbreviatedMonthNames;
        info.MonthNames = monthNames;
        info.AMDesignator = amDesignator;
        info.PMDesignator = pmDesignator;
        info.ShortDatePattern = shortDatePattern;
        info.FirstDayOfWeek = DayOfWeek.Saturday;
        var cal = calendar;
        var type = typeof(DateTimeFormatInfo);
        var fieldInfo = type.GetField("calendar", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        if (fieldInfo != null)
            fieldInfo.SetValue(info, cal);
        var field = typeof(CultureInfo).GetField("calendar",
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
        if (field != null)
            field.SetValue(calture, cal);
        Thread.CurrentThread.CurrentCulture = calture;
        Thread.CurrentThread.CurrentUICulture = calture;
        CultureInfo.CurrentCulture.DateTimeFormat = info;
        CultureInfo.CurrentUICulture.DateTimeFormat = info;
    }
}