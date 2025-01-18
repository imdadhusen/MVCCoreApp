using HisabPro.Constants;
using System.Globalization;

namespace HisabPro.Common
{
    public class FinanceYearHelper
    {
        public static (DateTime StartDate, DateTime EndDate) GetFinanceYearRange(EnumFinanceYear financeYear, int year)
        {
            switch (financeYear)
            {
                case EnumFinanceYear.JanToDec:
                    return (new DateTime(year, 1, 1), new DateTime(year, 12, 31));

                case EnumFinanceYear.AprToMar:
                    return (new DateTime(year, 4, 1), new DateTime(year + 1, 3, 31));

                case EnumFinanceYear.Islamic:
                    // Islamic calendar conversion
                    var islamicCalendar = new HijriCalendar();
                    DateTime islamicStart = new DateTime(year, 1, 1);
                    islamicStart = ConvertToGregorian(islamicCalendar, islamicStart);

                    DateTime islamicEnd = new DateTime(year, 12, 29);
                    islamicEnd = ConvertToGregorian(islamicCalendar, islamicEnd);

                    return (islamicStart, islamicEnd);

                default:
                    throw new ArgumentException("Invalid finance year type");
            }
        }

        private static DateTime ConvertToGregorian(HijriCalendar islamicCalendar, DateTime islamicDate)
        {
            return new DateTime(
                islamicCalendar.GetYear(islamicDate),
                islamicCalendar.GetMonth(islamicDate),
                islamicCalendar.GetDayOfMonth(islamicDate),
                islamicCalendar
            );
        }
    }
}
