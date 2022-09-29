using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MCU_PreCompiled_DateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime utcDate = DateTime.UtcNow;
            DateTime localDate = DateTime.Now;
            TimeSpan utcOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);

            int year = localDate.Year;
            int yr = localDate.Year % 100;
            int month = localDate.Month;
            int date = localDate.Day;
            int week = (int)localDate.DayOfWeek;

            int dow_dec_mo2su_127 = ((int)(localDate.DayOfWeek + 6) % 7) + 1;
            int dow_bits_mo2su_127 = dow_dec_mo2su_127;
            int dow_hex_mo2su_127 = (1 << dow_dec_mo2su_127);

            int dow_dec_su2sa_127 = (int)(localDate.DayOfWeek + 1);
            int dow_bits_su2sa_127 = dow_dec_su2sa_127;
            int dow_hex_su2sa_127 = (1 << dow_dec_su2sa_127);

            int dow_dec_su2sa_026 = (int)localDate.DayOfWeek;
            int dow_bits_su2sa_026 = dow_dec_su2sa_026;
            int dow_hex_su2sa_026 = (1 << dow_dec_su2sa_026);

            int dow_dec_mo2su_026 = ((int)(localDate.DayOfWeek + 6) % 7);
            int dow_bits_mo2su_026 = dow_dec_mo2su_026;
            int dow_hex_mo2su_026 = (1 << dow_dec_mo2su_026);

            int doy = localDate.DayOfYear;
            //int woy = ISOWeek.GetWeekOfYear(localDate);
            int hour = localDate.Hour;
            int hr12 = 0;
            int min = localDate.Minute;
            int sec = localDate.Second;
            int msec = localDate.Millisecond;
            int dst = 0;
            int am_pm = 0;
            int leap = 0;
            int gmt = utcOffset.Hours;

            if (DateTime.IsLeapYear(localDate.Year))
            {
                leap = 1;
            }

            if (localDate.Hour == 12)
            {
                hr12 = 12;
            }
            else
            {
                hr12 = localDate.Hour % 12;
            }

            if (localDate.Hour > 11)
            {
                am_pm = 1;
            }

            if (localDate.IsDaylightSavingTime())
            {
                dst = 1;
                gmt -= 1;
            }

            Console.WriteLine("#define PRECOMPILED_UTC_OFFSET	        {0}{1}", utcOffset.Hours.ToString().PadLeft(2, '0'), utcOffset.Minutes.ToString().PadLeft(2, '0'));
            Console.WriteLine("#define PRECOMPILED_UTC_HOUR_OFFSET	{0}", utcOffset.Hours.ToString());
            Console.WriteLine("#define PRECOMPILED_UTC_MIN_OFFSET	{0}", utcOffset.Minutes.ToString());
            Console.WriteLine("#define PRECOMPILED_GMT_HOUR_OFFSET  {0}", gmt.ToString());

            Console.WriteLine("");
            Console.WriteLine("#define PRECOMPILED_BIT_AM_PM    {0}       //  AM = 0, PM = 1", am_pm.ToString());
            Console.WriteLine("#define PRECOMPILED_BIT_DST	    {0}       //  DayLight Saving Time, yes = 1, no = 0", dst.ToString());
            Console.WriteLine("#define PRECOMPILED_BIT_LEAP	    {0}       //  LeapYear, yes = 1, no = 0", leap.ToString());

            Console.WriteLine("");
            Console.WriteLine("#define PRECOMPILED_DEC_MSEC	    {0}       //  MilliSeconds (0...999)", msec.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_SEC	    {0}       //  Seconds (0...59)", sec.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_MIN	    {0}       //  Minutes (0...59)", min.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_HOUR	    {0}       //  Hours (0...23)", hour.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_HR12	    {0}       //  Hours (0...12)", hr12.ToString());

            Console.WriteLine("");
            Console.WriteLine("#define PRECOMPILED_BIT_DOW	    {0}       //  ", dow_bits_mo2su_026.ToString());
            Console.WriteLine("#define PRECOMPILED_HEX_DOW	    {0}       //  ", dow_hex_mo2su_026.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DOW	    {0}       //  ", dow_dec_mo2su_127.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DOW_MO2SU_127  {0}       //  Monday to Sunday 1 to 7", dow_dec_mo2su_127.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DOW_SU2SA_127  {0}       //  Sunday to Saturday 1 to 7", dow_dec_su2sa_127.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DOW_MO2SU_026  {0}       //  Monday to Sunday 0 to 6", dow_dec_mo2su_026.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DOW_SU2SA_026  {0}       //  Sunday to Saturday 0 to 6", dow_dec_su2sa_026.ToString());

            Console.WriteLine("");
            //Console.WriteLine("#define PRECOMPILED_DEC_WOY	    {0}       //  Week Of Year (1...53)", woy.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DOY	    {0}       //  Day Of Year (0...366)", doy.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DOM	    {0}       //  Day of Month (1...31)", date.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_DATE	    {0}       //  Day of Month (1...31)", date.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_MTH	    {0}       //  Month (1...12)", month.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_SHORT_YEAR	{0}       //  Years last two digits in DECimal (00...99)", yr.ToString());
            Console.WriteLine("#define PRECOMPILED_DEC_YEAR	    {0}       //  Years in DECimal (0...till the end of time)", year.ToString());

            Console.WriteLine("");
            Console.Write("#define PRECOMPILED_DT_DEC_SHORT_ARRAY	{");
            Console.Write("{0},{1},{2},{3},{4},{5},{6}", sec.ToString(), min.ToString(), hour.ToString(), dow_dec_mo2su_127.ToString(), date.ToString(), month.ToString(), yr.ToString());
            Console.WriteLine("}");

            Console.Write("#define PRECOMPILED_DT_BCD_SHORT_ARRAY	{");
            Console.Write("0x{0},0x{1},0x{2},0x{3},0x{4},0x{5},0x{6}", sec.ToString().PadLeft(2, '0'), min.ToString().PadLeft(2, '0'), hour.ToString().PadLeft(2, '0'), dow_hex_mo2su_026.ToString().PadLeft(2, '0'), date.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0'), yr.ToString());
            Console.WriteLine("}");

            Console.Write("#define PRECOMPILED_DATE_DEC_SHORT_ARRAY	{");
            Console.Write("{0},{1},{2},", dow_dec_mo2su_026.ToString(), date.ToString(), month.ToString());
            Console.Write("{");
            Console.Write(" .i = {0}", yr.ToString());
            Console.WriteLine("}}");

            Console.Write("#define PRECOMPILED_TIME_DEC_ARRAY	{");
            Console.Write("{0},{1},{2}", sec.ToString(), min.ToString(), hour.ToString());
            Console.WriteLine("}");

            Console.Write("#define PRECOMPILED_DT_DEC_ARRAY	{");
            Console.Write("0,0,0,{0},{1},{2},{3},{4},{5},", sec.ToString(), min.ToString(), hour.ToString(), dow_dec_mo2su_127.ToString(), date.ToString(), month.ToString());
            Console.Write("{");
            Console.Write(" .i = {0}", yr.ToString());
            Console.WriteLine("}}");

            Console.Write("#define PRECOMPILED_DATE_BCD_ARRAY	{");
            Console.Write("0x{0},0x{1},0x{2},", dow_dec_mo2su_127.ToString().PadLeft(2, '0'), date.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0'));
            Console.Write("{");
            Console.Write(" .i = 0x{0}", year.ToString());
            Console.WriteLine("}}");

            Console.Write("#define PRECOMPILED_TIME_BCD_ARRAY	{");
            Console.Write("0x{0},0x{1},0x{2}", sec.ToString().PadLeft(2, '0'), min.ToString().PadLeft(2, '0'), hour.ToString().PadLeft(2, '0'));
            Console.WriteLine("}");

            Console.Write("#define PRECOMPILED_DT_BCD_ARRAY	{");
            Console.Write("0,0,0,0x{0},0x{1},0x{2},0x{3},0x{4},0x{5},", sec.ToString().PadLeft(2, '0'), min.ToString().PadLeft(2, '0'), hour.ToString().PadLeft(2, '0'), dow_dec_mo2su_127.ToString().PadLeft(2, '0'), date.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0'));
            Console.Write("{");
            Console.Write(" .i = 0x{0}", year.ToString());
            Console.WriteLine("}}");
        }
    }
}
